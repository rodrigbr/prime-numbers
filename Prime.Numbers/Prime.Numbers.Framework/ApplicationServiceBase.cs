using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Prime.Numbers.Framework.DTOs.Validation;

namespace Prime.Numbers.Framework
{
    public abstract class ApplicationServiceBase
    {
        public ValidationResult ValidationResult { get; protected set; } = new ValidationResult();

        public void AddValidationError(string error, string description)
        {
            ValidationResult.Errors.Add(new ValidationFailure(error, description));
        }

        protected ValidationResultDTO<T> CustomValidationDataResponse<T>(object response)
        {
            ValidationResultDTO<T> ValidationResultWithDataResponse = new ValidationResultDTO<T>();

            T newResponse = (T)Convert.ChangeType(response, typeof(T));

            ValidationResultWithDataResponse.Response = newResponse;

            if (ValidationResult.Errors.Any())
                ValidationResultWithDataResponse.ValidationProblemDetails = new ValidationProblemDetails(new Dictionary<string, string[]>
                {
                    { "Messages", ValidationResult.Errors.Select(x=> x.ErrorMessage).ToArray() }
                });

            return ValidationResultWithDataResponse;
        }

        protected ValidationResultDTO<T> CustomValidationDataResponse<T>(params object[] response)
        {
            ValidationResultDTO<T> ValidationResultWithDataResponse = new ValidationResultDTO<T>();

            T[] newResponse = (T[])Convert.ChangeType(response, typeof(T[]));

            ValidationResultWithDataResponse.ListResponse = newResponse;

            if (ValidationResult.Errors.Any())
                ValidationResultWithDataResponse.ValidationProblemDetails = new ValidationProblemDetails(new Dictionary<string, string[]>
                {
                    { "Messages", ValidationResult.Errors.Select(x=> x.ErrorMessage).ToArray() }
                });

            return ValidationResultWithDataResponse;
        }
    }
}
