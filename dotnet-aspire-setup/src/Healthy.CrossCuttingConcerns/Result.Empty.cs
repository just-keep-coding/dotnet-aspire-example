namespace Healthy.CrossCuttingConcerns;

public class Result : Result<object>
{
    private Result(bool isSuccess, string? message = null)
        : base(isSuccess, message)
    {
    }

    public static Result Success()
    {
        return new Result(true);
    }

    public static Result<T> Success<T>(T value)
    {
        return Result<T>.Success(value);
    }

    public static Result Failure()
    {
        return new Result(false);
    }
}
