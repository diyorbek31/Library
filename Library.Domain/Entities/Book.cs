using Library.Domain.Commons;

namespace Library.Domain.Entities;

public class Book : Auditable
{
    public string Title {  get; set; }
    public string Category { get; set; }
    public bool IsAvaiable { get; set; }
    public string Author { get; set; }

}
