namespace SyncScene.Domain.Exceptions;

public class AlreadyExistException : BaseCustomException
{
    
    public AlreadyExistException() : base(ExceptionMessages.AlreadyExistException, 409)
    {
    }
    
}