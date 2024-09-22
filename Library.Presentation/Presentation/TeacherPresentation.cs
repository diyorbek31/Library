using Library.Domain.Entities;
using Library.Service.DTOs.Teachers;
using Library.Service.Services;

namespace Library.Presentation.Presentation;

public class TeacherPresentation
{
    public static async Task Show()
    {
        TeacherService teacherService = new TeacherService();
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
                Teacher teacher = new Teacher();
                switch (number)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Enter the User Firstname -> ");
                        teacher.FirstName = Console.ReadLine();

                        Console.Write("Enter the User Lastname -> ");
                        teacher.LastName = Console.ReadLine();

                        Console.Write("Enter the User Email");
                        teacher.Email = Console.ReadLine();

                        Console.Write("Enter the User PhoneNumber");
                        teacher.PhoneNumber = Console.ReadLine();
                        teacherService.AddAsync(teacher);
                        break;
                    case 2:

                        Console.Clear();
                        Console.Write("Enter the UserId -> ");
                        int userId = int.Parse(Console.ReadLine());
                        TeacherForUpdateDto teacherUpd = new TeacherForUpdateDto();

                        Console.Write("Enter the User Firstname -> ");
                        teacherUpd.FirstName = Console.ReadLine();
                        Console.Write("Enter the User Lastname -> ");
                        teacherUpd.LastName = Console.ReadLine();
                        Console.Write("Enter the User PhoneNumber");
                        teacherUpd.PhoneNumber = Console.ReadLine();
                        Console.WriteLine("Enter the User Email -> ");
                        teacherUpd.Email = Console.ReadLine();                        
                        teacherService.UpdateAsync(userId, teacherUpd);
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter the UserId -> ");
                        int teacherId = int.Parse(Console.ReadLine());
                        var teacherInfo = await teacherService.GetByIdAsync(teacherId);

                        Console.WriteLine($"Firstname : {teacherInfo.FirstName}, Lastname : {teacherInfo.LastName}, Phonenumbers : {teacherInfo.PhoneNumber}");

                        break;
                    case 4:
                        Console.Clear();
                        var teachersInfo = await teacherService.GetAllAsync();
                        foreach (var tutor in teachersInfo)
                        {
                            Console.WriteLine($"Firstname : {tutor.FirstName}, Lastname : {tutor.LastName}, Phonenumbers : {tutor.PhoneNumber}");

                        }
                        break;

                    case 5:
                        Console.Clear();
                        Console.Write("Enter the UserId -> ");
                        int tutorId = int.Parse(Console.ReadLine());

                        var deleteResponse = await teacherService.DeleteByIdAsync(tutorId);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}