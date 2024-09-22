using Library.Domain.Entities;
using Library.Service.DTOs.Books;

using Library.Service.Services;

namespace Library.Presentation.Presentation;

public class BookPresentation
{
    public static async Task Show()
    {
        BookService bookService = new BookService();
        bool check = true;
        while (check)
        {
            try
            {
                Console.WriteLine("1 -> Register new Book");
                Console.WriteLine("2 -> Update Book");
                Console.WriteLine("3 -> Get by Id ");
                Console.WriteLine("4 -> Get All");
                Console.WriteLine("5 -> Delete Book By Id");
                Console.WriteLine("6 -> Search By Authot");
                Console.WriteLine("7 -> Search By Title");
                Console.WriteLine("8 -> Check Availibity");
                Console.WriteLine("9 ->  Close");

                int number = int.Parse(Console.ReadLine());
                Book book = new Book();
                switch (number)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Enter the Book Title -> ");
                        book.Title = Console.ReadLine();

                        Console.Write("Enter the Book Author -> ");
                        book.Author = Console.ReadLine();

                        Console.Write("Avaibility status -> ");
                        book.IsAvaiable = bool.Parse(Console.ReadLine());

                        Console.Write("Enter the Category");
                        book.Category = Console.ReadLine();

                        bookService.AddAsync(book);
                        break;
                    case 2:

                        Console.Clear();
                        Console.Write("Enter the BookId -> ");
                        int bookId = int.Parse(Console.ReadLine());
                        BookForUpdateDto bookUpd = new BookForUpdateDto();
                        Console.Write("Enter the Book Title -> ");
                        bookUpd.Title = Console.ReadLine();
                        Console.Write("Avaibility status -> ");
                        Console.Write("Enter the Category");
                        bookUpd.Category = Console.ReadLine();

                        bookService.UpdateAsync(bookId, bookUpd);
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter the BookId -> ");
                        int id = int.Parse(Console.ReadLine());
                        var bookInfo = await bookService.GetByIdAsync(id);

                        Console.WriteLine($"Title : {bookInfo.Title}, Avaiable : {bookInfo.IsAvaiable}");

                        break;
                    case 4:
                        Console.Clear();
                        var booksInfo = await bookService.GetAllAsync();
                        foreach (var bookk in booksInfo)
                        {
                            Console.WriteLine($"Firstname : {bookk.Title}, Category : {bookk.Category}, Phonenumbers : {bookk.IsAvaiable}");
                        }
                        break;

                    case 5:
                        Console.Clear();
                        Console.Write("Enter the BookId -> ");
                        int bookkId = int.Parse(Console.ReadLine());

                        var deleteResponse = await bookService.DeleteByIdAsync(bookkId);
                        if (deleteResponse)
                            Console.WriteLine("Successfully deleted!");

                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Enter the Author of Book -> ");
                        string author = Console.ReadLine();
                        var sortedBooksByAuthor = await bookService.SearchByAuthorAsync(author);

                        foreach (var sortedBook in sortedBooksByAuthor)
                        {
                            Console.WriteLine($"Title : {sortedBook.Title},Availability : {sortedBook.IsAvaible}");
                        }
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Enter the Title of Book -> ");
                        var title = Console.ReadLine();
                        var sortedBooksByTitle = await bookService.SearchByTitleAsync(title);

                        foreach (var sortedBook in sortedBooksByTitle)
                        {
                            Console.WriteLine($"Author : {sortedBook.Author}, Availability : {sortedBook.IsAvaiable}");
                        }

                        break;
                    case 8:
                        Console.Clear();
                        Console.Write("Enter the Book Id -> ");
                        var bookid = int.Parse(Console.ReadLine());
                        var checkStatus = await bookService.IsAvaibleAsync(bookid);
                        if (checkStatus)
                            Console.WriteLine("Available :)");
                        else
                            Console.WriteLine("Not Available (:");

                        break;
                    case 9:
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
