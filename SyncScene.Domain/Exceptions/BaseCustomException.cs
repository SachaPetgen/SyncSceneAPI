namespace SyncScene.Domain.Exceptions;

public class BaseCustomException : Exception
{
    
    public int StatusCode { get; set; }
    
    public BaseCustomException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
    
}