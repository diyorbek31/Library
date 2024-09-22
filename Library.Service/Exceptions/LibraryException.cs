namespace Library.Service.Exceptions;

public class LibraryException : Exception
{
    public int statusCode { get; set; }
    public LibraryException(int statusCode,string message) : base(message)
    {
        this.statusCode = statusCode;
    }

    
}
