pipeline {
    agent any

    environment {
        AWS_CRED   = credentials('aws-healthcare')
        DB_HOST    = credentials('db-host')
        DB_PASS    = credentials('db-password')
        JWT_KEY    = credentials('jwt-secret')
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
            steps { bat 'dotnet build --no-restore' }
        }

        stage('Test') {
            steps { bat 'dotnet test --no-build' }
        }

        stage('Build Angular + Publish .NET') {
            steps {
                dir('HealthCare.Portal') {
                    bat 'npm ci'
                    bat 'ng build --configuration production'
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

        stage('Write .ebextensions') {
            steps {
                writeFile file: '.ebextensions/01-environment.config', text: """
option_settings:
  aws:elasticbeanstalk:application:environment:
    ASPNETCORE_ENVIRONMENT: "Production"
    ConnectionStrings__Default: "Server=${DB_HOST},1433;Database=HealthCareDb;User Id=sa;Password=${DB_PASS};TrustServerCertificate=True"
    RabbitMq__Host: "${DB_HOST}"
    RabbitMq__Username: "guest"
    RabbitMq__Password: "guest"
    Jwt__Key: "${JWT_KEY}"
    Jwt__Issuer: "HealthCare"
    Jwt__Audience: "HealthCare"
    Jwt__AccessTokenExpirationMinutes: "15"
    SeedData__AdminEmail: "admin@healthcare.com"
    SeedData__AdminPassword: "Admin@123"
"""
            }
        }

        stage('Create deploy.zip') {
            steps {
                bat '''
                    7z a deploy.zip ^
                      Dockerfile .dockerignore .ebextensions publish ^
                      HealthCare.Portal\\dist\\HealthCare.Portal\\browser ^
                      -xr!docker-compose.yml -xr!*.user -xr!*.Development.json
                '''
            }
        }

        stage('Upload to S3') {
            steps {
                bat "aws s3 cp deploy.zip s3://%BUCKET%/deploy-%BUILD_NUMBER%.zip --region %REGION%"
            }
        }

        stage('Create App Version') {
            steps {
                bat """
                    aws elasticbeanstalk create-application-version ^
                      --application-name %APP_NAME% ^
                      --version-label v%BUILD_NUMBER% ^
                      --source-bundle S3Bucket="%BUCKET%",S3Key="deploy-%BUILD_NUMBER%.zip" ^
                      --region %REGION%
                """
            }
        }

        stage('Deploy or Create Environment') {
            steps {
                script {
                    def envExists = bat(
                        script: """
                            aws elasticbeanstalk describe-environments ^
                              --application-name %APP_NAME% ^
                              --query "Environments[?Status!='Terminated'].EnvironmentName" ^
                              --output text --region %REGION%
                        """,
                        returnStdout: true
                    ).trim()

                    if (envExists) {
                        echo "Environment exists — updating..."
                        bat """
                            aws elasticbeanstalk update-environment ^
                              --environment-name %ENV_NAME% ^
                              --version-label v%BUILD_NUMBER% ^
                              --region %REGION%
                        """
                    } else {
                        echo "No environment — creating from template..."
                        bat """
                            aws elasticbeanstalk create-environment ^
                              --application-name %APP_NAME% ^
                              --environment-name %ENV_NAME% ^
                              --template-name HealthCare-template ^
                              --version-label v%BUILD_NUMBER% ^
                              --region %REGION%
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
                      --region %REGION%
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
