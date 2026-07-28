pipeline {
    agent any

    environment {
        AWS_CRED   = credentials('aws-healthcare')
        APP_NAME   = 'HealthCare'
        ENV_NAME   = 'HealthCare-env'
        BUCKET     = 'elasticbeanstalk-ap-southeast-2-181486424621'
        REGION     = 'ap-southeast-2'
    }

    stages {
        stage('Restore') {
            steps { bat 'dotnet restore' }
        }

        stage('Build') {
            steps { bat 'dotnet build --no-restore -c Release' }
        }

        stage('Test') {
            steps { bat 'dotnet test --no-build -c Release' }
        }

        stage('Build Angular + Publish .NET') {
            steps {
                dir('HealthCare.Portal') {
                    bat 'npm ci'
                    bat '.\\node_modules\\.bin\\ng.cmd build --configuration production'
                }
                bat 'dotnet publish HealthCare.Api -c Release -o publish/api --no-build'
                bat 'dotnet publish HealthCare.Admin -c Release -o publish/admin --no-build'
                powershell '''
                    (Get-Content publish/admin/wwwroot/index.html) -replace
                    '<base href="/"', '<base href="/admin/"' |
                    Set-Content publish/admin/wwwroot/index.html
                '''
            }
        }

        stage('Create deploy.zip') {
            steps {
                bat '''
                    "C:\\Program Files\\7-Zip\\7z.exe" a deploy.zip ^
                      Dockerfile .dockerignore .ebextensions publish ^
                      HealthCare.Portal\\dist\\HealthCare.Portal\\browser ^
                      -xr!docker-compose.yml -xr!*.user -xr!*.Development.json
                '''
            }
        }

        stage('Upload to S3') {
            steps {
                bat "aws s3 cp deploy.zip s3://%BUCKET%/deploy-%BUILD_NUMBER%.zip --region %REGION% --no-verify-ssl"
            }
        }

        stage('Create App Version') {
            steps {
                bat """
                    aws elasticbeanstalk create-application-version ^
                      --application-name %APP_NAME% ^
                      --version-label v%BUILD_NUMBER% ^
                      --source-bundle S3Bucket="%BUCKET%",S3Key="deploy-%BUILD_NUMBER%.zip" ^
                      --region %REGION% --no-verify-ssl
                """
            }
        }

        stage('Deploy or Create Environment') {
            steps {
                script {
                    def exitCode = bat(
                        script: """
                            aws elasticbeanstalk update-environment ^
                              --environment-name %ENV_NAME% ^
                              --version-label v%BUILD_NUMBER% ^
                              --region %REGION% --no-verify-ssl
                        """,
                        returnStatus: true
                    )
                    if (exitCode != 0) {
                        echo "Update failed (env may not exist) — creating from template..."
                        bat """
                            aws elasticbeanstalk create-environment ^
                              --application-name %APP_NAME% ^
                              --environment-name %ENV_NAME% ^
                              --template-name HealthCare-env ^
                              --version-label v%BUILD_NUMBER% ^
                              --region %REGION% --no-verify-ssl
                        """
                    }
                }
            }
        }

        stage('Wait for Deployment') {
            steps {
                bat """
                    aws elasticbeanstalk wait environment-updated ^
                      --environment-name %ENV_NAME% ^
                      --region %REGION% --no-verify-ssl
                """
            }
        }
    }

    post {
        success {
            echo "Deployed v${BUILD_NUMBER} to ${ENV_NAME}"
        }
        failure {
            echo "Build failed — check Jenkins console"
        }
    }
}
