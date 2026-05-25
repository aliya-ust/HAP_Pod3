using Xunit;
using HealthApp.ConsoleApp.Helpers;

namespace HealthApp.Tests.Helpers
{
    public class InputValidatorTests
    {
        // Name
        [Fact]
        public void IsValidName_ShouldReturnTrue_ForValidName()
        {
            Assert.True(InputValidator.IsValidName("John Doe"));
        }

        [Fact]
        public void IsValidName_ShouldReturnFalse_ForNameWithDigits()
        {
            Assert.False(InputValidator.IsValidName("John123"));
        }

        // Phone
        [Fact]
        public void IsValidPhone_ShouldReturnTrue_ForValidPhone()
        {
            Assert.True(InputValidator.IsValidPhone("9999999999"));
        }

        [Fact]
        public void IsValidPhone_ShouldReturnFalse_ForInvalidPhone()
        {
            Assert.False(InputValidator.IsValidPhone("12345"));
        }

        // Email
        [Fact]
        public void IsValidEmail_ShouldReturnTrue_ForValidEmail()
        {
            Assert.True(InputValidator.IsValidEmail("test@example.com"));
        }

        [Fact]
        public void IsValidEmail_ShouldReturnFalse_ForInvalidEmail()
        {
            Assert.False(InputValidator.IsValidEmail("test.com"));
        }

        // Insurance ID
        [Fact]
        public void IsValidInsuranceId_ShouldReturnTrue_ForValidInput()
        {
            Assert.True(InputValidator.IsValidInsuranceId("123"));
        }

        [Fact]
        public void IsValidInsuranceId_ShouldReturnFalse_ForNegative()
        {
            Assert.False(InputValidator.IsValidInsuranceId("-1"));
        }

        // Experience
        [Fact]
        public void IsValidExperience_ShouldReturnTrue_ForValidInput()
        {
            Assert.True(InputValidator.IsValidExperience("10"));
        }

        [Fact]
        public void IsValidExperience_ShouldReturnFalse_ForInvalidInput()
        {
            Assert.False(InputValidator.IsValidExperience("-5"));
        }

        // Fee
        [Fact]
        public void IsValidFee_ShouldReturnTrue_ForValidFee()
        {
            Assert.True(InputValidator.IsValidFee("250.50"));
        }

        [Fact]
        public void IsValidFee_ShouldReturnFalse_ForInvalidFee()
        {
            Assert.False(InputValidator.IsValidFee("-10"));
        }

        // ID
        [Fact]
        public void IsValidId_ShouldReturnTrue_ForPositiveId()
        {
            Assert.True(InputValidator.IsValidId("101"));
        }

        [Fact]
        public void IsValidId_ShouldReturnFalse_ForZeroOrNegative()
        {
            Assert.False(InputValidator.IsValidId("0"));
        }

        // NonEmpty
        [Fact]
        public void IsNonEmpty_ShouldReturnTrue_WhenNotEmpty()
        {
            Assert.True(InputValidator.IsNonEmpty("Hello"));
        }

        [Fact]
        public void IsNonEmpty_ShouldReturnFalse_WhenEmpty()
        {
            Assert.False(InputValidator.IsNonEmpty(""));
        }
    }
}