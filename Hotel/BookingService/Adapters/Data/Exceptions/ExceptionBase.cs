using System.Runtime.Serialization;

namespace Data.Exceptions;

public class ExceptionBase : SystemException
{
    public ExceptionBase(string message) : base(message)
    {
    }

    protected ExceptionBase(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}