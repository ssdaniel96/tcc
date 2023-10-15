using Domain.Exceptions;

namespace Application.Exceptions;

public class ApplicationException : BaseException
{
    public ApplicationException(string message) : base(message)
    {
        
    }
    
    public ApplicationException(string message, Exception innerException) 
        : base(message, innerException)
    {
        
    }
}