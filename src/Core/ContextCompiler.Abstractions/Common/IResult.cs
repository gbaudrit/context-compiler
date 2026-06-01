namespace ContextCompiler.Abstractions.Common;

public interface IResult
{
    static IResult<T> Failure<T>(string message)
    {
        return new Result<T>.FailureResult(default, message, null, int.MinValue);
    }

    static IResult<T> Failure<T>(T? value, string message, Exception ex, int StatusCode = int.MinValue)
    {
        return new Result<T>.FailureResult(value, message, ex, StatusCode);
    }

    static IResult<T> Failure<T>(T? value, string message, int StatusCode = int.MinValue)
    {
        return new Result<T>.FailureResult(value, message, null, StatusCode);
    }

    static IResult<T> Success<T>(T value)
    {
        return new Result<T>.SuccessResult(value);
    }
}

public interface IResult<T>
{

}

public interface ISuccessResult<T> : IResult<T>
{
    T Value { get; }
}

public interface IFailureResult<T> : IResult<T>
{
    T? Value { get; }
    string Message { get; }
    int StatusCode { get; }
}
