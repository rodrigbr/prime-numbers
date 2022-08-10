using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Prime.Numbers.Application.Helpers
{
    public abstract class BaseCQ
    {
        public virtual List<ValidationResult> Validate()
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this, context, validationResults, true);

            ValidateCommandRequired(validationResults);

            return validationResults;
        }

        private void ValidateCommandRequired(List<ValidationResult> validationResults)
        {
            var customRequiredProperties = this.GetType().GetProperties()
                .Where(x => x.GetCustomAttribute<CommandRequiredAttribute>() != null);

            foreach(var property in customRequiredProperties)
            {
                var value = property.GetValue(this);
                if(value == null || (value.GetType() == typeof(Guid) && (Guid)value == Guid.Empty))
                {
                    validationResults.Add(new ValidationResult("Field is required", new List<string>() { property.Name }));
                }
            }
        }
    }
}
