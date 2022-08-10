using Microsoft.AspNetCore.Mvc;

namespace Prime.Numbers.Framework.DTOs.Validation
{
    public class ValidationResultDTO<T>
    {
        public ValidationProblemDetails ValidationProblemDetails { get; set; }

        public T Response { get; set; }

        public T[] ListResponse { get; set; }
    }
}
