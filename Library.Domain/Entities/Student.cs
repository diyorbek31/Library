using Library.Domain.Commons;

namespace Library.Domain.Entities;

public class Student : Auditable
{
    public string FirstName {  get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int PhoneNumber {  get; set; }
    public int Course { get; set; }
    public bool MembershipStatus {  get; set; }

}
