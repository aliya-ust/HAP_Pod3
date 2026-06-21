using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HealthCare.Api.Attributes
{
    public class AllowedValuesAttribute : ValidationAttribute
    {
        private readonly string[] _allowed;

        public AllowedValuesAttribute(params string[] allowed)
        {
            _allowed = allowed ?? new string[0];
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var str = value.ToString();
            if (_allowed.Contains(str))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage ?? $"The field {validationContext.MemberName} must be one of: {string.Join(", ", _allowed)}.");
        }
    }
}
