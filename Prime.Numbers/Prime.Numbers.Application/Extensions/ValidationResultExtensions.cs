using System.ComponentModel.DataAnnotations;
using Prime.Numbers.Application.Helpers;

namespace Prime.Numbers.Application.Extensions
{
    public static class ValidationResultExtensions
    {
        public static OperationResult<T> ToOperationResult<T>(this List<ValidationResult> validationResults, string operationName = null) where T : class
        {
            var operationResult = new OperationResult<T>(operationName)
            {
                Succeeded = false
            };
            validationResults.ForEach(validationResult => operationResult.AddError(validationResult.MemberNames.First(), validationResult.ErrorMessage));

            return operationResult;
        }

        public static OperationResult ToOperationResult(this List<ValidationResult> validationResults, string operationName = null)
        {
            var operationResult = new OperationResult(operationName)
            {
                Succeeded = false
            };
            validationResults.ForEach(validationResult => operationResult.AddError(validationResult.MemberNames.First(), validationResult.ErrorMessage));

            return operationResult;
        }
    }
}
