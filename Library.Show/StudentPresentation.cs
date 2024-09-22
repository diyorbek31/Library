using Library.Domain.Entities;
using Library.Service.Services;

namespace Library.Show;

public  class StudentPresentation
{
    public async void Show()
    {
        StudentService studentService = new StudentService();
        bool check = true;
        while(check)
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
                }

            }
        }
    }
}
