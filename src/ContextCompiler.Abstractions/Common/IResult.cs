namespace ContextCompiler.Abstractions.Common;

public interface IResult
{
    static IResult<T> Failure<T>(string message, int StatusCode = int.MinValue)
    {
        return new Result<T>.FailureResult(message, StatusCode);
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
    string Message { get; }
    int StatusCode { get; }
}
