namespace ShopSystem.Services.Exceptions;
using Microsoft.AspNetCore.Http;

public abstract class BusinessException : Exception
{
    protected BusinessException(string message, string errorCode)
        : base(message)
    {
        ErrorCode = errorCode;
    }

    public string ErrorCode { get; }
    public abstract int StatusCode { get; }
}

public class NotFoundException<TId> : BusinessException
{
    public NotFoundException(TId id)
        : base($"Entity {id} not found", "NOT_FOUND")
    {
    }

    public override int StatusCode => StatusCodes.Status404NotFound;
}

public class BusinessRuleException : BusinessException
{
    public BusinessRuleException(string rule)
        : base(rule, "BUSINESS_RULE_VIOLATION") { }

    public override int StatusCode => StatusCodes.Status422UnprocessableEntity;
}