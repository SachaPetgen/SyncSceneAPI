namespace SyncScene.Domain.Exceptions;

public class AlreadyExistException : BaseCustomException
{
    
    public AlreadyExistException(string message) : base(message, 409)
    {
    }
    
}