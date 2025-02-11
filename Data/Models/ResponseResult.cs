namespace Infrastructure.Models;

public class ResponseResult<T>(bool success, int statusCode, string? errorMessage, T? result) : ResponseResult(success, statusCode, errorMessage)
{
    public T? Result { get; set; } = result;
}

public class ResponseResult(bool success, int statusCode, string? errorMessage)
{
    public bool Success { get; set; } = success;
    public int StatusCode { get; set; } = statusCode;
    public string? ErrorMessage { get; set; } = errorMessage;
}