namespace CrossCuttingConcerns;

public class Result<T>
{
    public T? Value { get; }

    public string? Message { get; }

    public bool IsSuccess { get; }

    public bool IsError => !IsSuccess;

    private Result(bool isSuccess, T value, string? message = null) : this(isSuccess, message)
    {
        Value = value;
    }
    
    protected Result(bool isSuccess, string? message = null)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(true, value);
    }

    public static Result<T> Failure(T value)
    {
        return new Result<T>(false, value);
    }

    public static implicit operator Result<T>(Result result)
        => new(result.IsSuccess, result.Message);
}
