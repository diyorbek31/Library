namespace Library.Service.Exceptions;

public class BookException : Exception
{
    public int statusCode { get; set; }
    public BookException(int statusCode,string message) : base(message)
    {
        this.statusCode = statusCode;
    }

    
}
