namespace SyncScene.Domain.Exceptions;

public class NotFoundException : BaseCustomException
{
    public NotFoundException() : base(ExceptionMessages.NotFoundException, 404)
    {
    }
}