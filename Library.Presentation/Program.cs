

using Library.Presentation.Presentation;

namespace Library.Presentation;

public class Program
{
    static async void Main(string[] args)
    {
        while (true)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("\n\t\t\tWelcome to the Learning Research Centre!!!");
                Console.WriteLine("\t\t\t\t\t1 - Students");
                Console.WriteLine("\t\t\t\t\t2 - Teachers ");
                Console.WriteLine("\t\t\t\t\t3 - Books ");
                Console.WriteLine("\t\t\t\t\t4 - Booking");
                Console.WriteLine("\t\t\t\t\t5 - Exit");

                Console.Write("\t\t\t\t\tEnter your option -> ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Clear();
                    await StudentPresentation.Show();
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    await TeacherPresentation.Show();
                }
                else if (choice == 3)
                {
                    Console.Clear();
                    await BookPresentation.Show();
                }
                else if (choice == 4)
                {
                    Console.Clear();
                    Console.WriteLine("It is not available now");
                    //await BookingPresentation.Show();
                }
                else if (choice == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Thank you :)");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid number! Please try again!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
     }
}
