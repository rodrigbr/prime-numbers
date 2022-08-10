using Microsoft.Extensions.Logging;

namespace Prime.Numbers.Application.Helpers
{
    public class OperationResult : BaseOperationResult
    {

        public OperationResult(string name = null) : base(name)
        {
        }

        public static OperationResult CreateSuccess(string name = null)
        {
            return new OperationResult(name).Succeed();
        }

        public static OperationResult CreateFailure(string error = null, string name = null, BaseCQ command = null, LogLevel logLevel = LogLevel.Debug)
        {
            return new OperationResult(name).Fail(error, command, logLevel);
        }

        public OperationResult Succeed()
        {
            Succeeded = true;
            return this;
        }

        public OperationResult Fail(string error = null, BaseCQ command = null, LogLevel logLevel = LogLevel.Debug)
        {
            if (error != null)
            {
                AddGenericError(error);
            }
            LogLevel = logLevel;
            Succeeded = false;
            return this;
        }

        public OperationResult SetLogLevel(LogLevel logLevel)
        {
            LogLevel = logLevel;
            return this;
        }
    }


    public class OperationResult<T> : BaseOperationResult where T : class
    {
        public T Object { get; set; }

        public OperationResult(string name = null) : base(name)
        {
        }

        public static OperationResult<T> CreateSuccess(T obj, string name = null)
        {
            return new OperationResult<T>(name).Succeed(obj);
        }

        public static OperationResult<T> CreateFailure(string description, string name = null, BaseCQ command = null, LogLevel logLevel = LogLevel.Debug)
        {
            return new OperationResult<T>(name).Fail(description, command, logLevel);
        }

        public static OperationResult<T> CreateFailure(string source, string description, string name = null, BaseCQ command = null, LogLevel logLevel = LogLevel.Debug)
        {
            return new OperationResult<T>(name).Fail(source, description, command, logLevel);
        }

        public OperationResult<T> Succeed(T obj, string name = null)
        {
            Succeeded = true;
            Object = obj;
            return this;
        }

        public OperationResult<T> Fail(string description, BaseCQ command = null, LogLevel logLevel = LogLevel.Debug)
        {
            LogLevel = logLevel;
            AddGenericError(description);
            return this;
        }

        public OperationResult<T> Fail(string source, string description, BaseCQ command = null, LogLevel logLevel = LogLevel.Debug)
        {
            LogLevel = logLevel;
            AddError(source, description);
            return this;
        }

        public OperationResult<T> SetLogLevel(LogLevel logLevel)
        {
            LogLevel = logLevel;
            return this;
        }

        public void From(OperationResult<T> operationResult)
        {
            Object = operationResult.Object;
            Errors = operationResult.Errors;
            Succeeded = operationResult.Succeeded;
            LogLevel = operationResult.LogLevel;
        }
    }

    public class OperationError
    {
        public static string GenericError = "error";
        public string Source { get; set; }
        public string Description { get; set; }

        public OperationError(string source, string description)
        {
            Source = source;
            Description = description;
        }
    }

    public abstract class BaseOperationResult
    {
        public LogLevel LogLevel { get; set; }
        public bool Succeeded { get; set; }
        public List<OperationError> Errors { get; set; }

        protected BaseOperationResult(string name)
        {
            LogLevel = LogLevel.Debug;
            Errors = new List<OperationError>();
        }

        public void From(BaseOperationResult operationResult)
        {
            Errors = operationResult.Errors;
            Succeeded = operationResult.Succeeded;
        }

        public void AddError(string source, string description)
        {
            Succeeded = false;
            Errors.Add(new OperationError(source, description));
        }

        public void AddGenericError(string description)
        {
            Succeeded = false;
            Errors.Add(new OperationError("Error", description));
        }
    }

}
