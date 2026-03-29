namespace ContextCompiler.Abstractions.Common;

public abstract record Result<T> : IResult<T>
{
    private Result() { }
    public sealed record SuccessResult(T Value) : Result<T>, ISuccessResult<T>;
    public sealed record FailureResult(string Message, int StatusCode = int.MinValue) : Result<T>, IFailureResult<T>;


}
