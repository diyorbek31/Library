namespace Library.Presentation.Presentation;

using Library.Domain.Entities;
using Library.Service.DTOs.Students;
using Library.Service.Services;

public class StudentPresentation
{
    public static async Task Show()
    {
        StudentService studentService = new StudentService();
        bool check = true;
        while (check)
        {
            try
            {
                Console.WriteLine("1 -> Register new User");
                Console.WriteLine("2 -> Update User");
                Console.WriteLine("3 -> Get by Id ");
                Console.WriteLine("4 -> Get All");
                Console.WriteLine("5 -> Delete User By Id");
                Console.WriteLine("6 -> Close");

                int number = int.Parse(Console.ReadLine());
                Student student = new Student();
                switch (number)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Enter the User Firstname -> ");
                        student.FirstName = Console.ReadLine();

                        Console.Write("Enter the User Lastname -> ");
                        student.LastName = Console.ReadLine();

                        Console.Write("Enter the User Email");
                        student.Email = Console.ReadLine();

                        Console.Write("Enter the User PhoneNumber");
                        student.PhoneNumber = int.Parse(Console.ReadLine());

                        Console.Write("Enter the User Course");
                        student.Course = int.Parse(Console.ReadLine());

                        Console.WriteLine("Membership is Avaiable ?(1/0) -> ");
                        student.MembershipStatus = bool.Parse(Console.ReadLine());

                        studentService.AddAsync(student);
                        break;
                    case 2:

                        Console.Clear();
                        Console.Write("Enter the UserId -> ");
                        int userId = int.Parse(Console.ReadLine());
                        StudentForUpdateDto studentUpd = new StudentForUpdateDto();

                        Console.Write("Enter the User Firstname -> ");
                        studentUpd.FirstName = Console.ReadLine();
                        Console.Write("Enter the User Lastname -> ");
                        studentUpd.LastName = Console.ReadLine();
                        Console.Write("Enter the User PhoneNumber");
                        studentUpd.PhoneNumber = (Console.ReadLine());
                        Console.WriteLine("Membership is Avaiable ?(1/0) -> ");
                        studentUpd.MembershipStatus = bool.Parse(Console.ReadLine());

                        studentService.UpdateAsync(userId, studentUpd);
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter the UserId -> ");
                        int studentId = int.Parse(Console.ReadLine());
                        var studentInfo = await studentService.GetByIdAsync(studentId);

                        Console.WriteLine($"Firstname : {studentInfo.FirstName}, Lastname : {studentInfo.LastName}, Phonenumbers : {studentInfo.PhoneNumber}, MembershipStatus : {studentInfo.MembershipStatus}");

                        break;
                    case 4:
                        Console.Clear();
                        var studentsInfo = await studentService.GetAllAsync();
                        foreach(var pupil in studentsInfo)
                        {
                            Console.WriteLine($"Firstname : {pupil.FirstName}, Lastname : {pupil.LastName}, Phonenumbers : {pupil.PhoneNumber}, MembershipStatus : {pupil.MembershipStatus}");

                        }
                        break;

                    case 5:
                        Console.Clear();
                        Console.Write("Enter the UserId -> ");
                        int pupilId = int.Parse(Console.ReadLine());

                        var deleteResponse = await studentService.DeleteByIdAsync(pupilId);
                        if (deleteResponse)
                            Console.WriteLine("Successfully deleted!");
                        
                        break;

                    case 6:
                        Console.Clear();
                        Console.WriteLine("Thank you)))");
                        check = false;
                        break;

                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
