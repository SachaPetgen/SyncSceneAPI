namespace SyncScene.Domain.Exceptions;

public class AlreadyExistException : BaseCustomException
{
    
    public AlreadyExistException(string message) : base(message + ExceptionMessages.AlreadyExistException, 409)
    {
    }
    
}