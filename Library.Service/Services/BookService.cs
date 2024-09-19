using Library.Domain.Entities;
using Library.Service.DTOs.Books;
using Library.Service.Interfaces;
using Library.Data.IRepositories;
using Library.Data.Repositories;
using Library.Service.Exceptions;

namespace Library.Service.Services;

public class BookService : IBookService
{
    IRepository<Book> bookRepository = new Repository<Book>();
    public async Task<bool> AddAsync(Book book)
    {
        var books = await this.bookRepository.RetrievAllAsync();
        if (books.Any(b => b.Title.Equals(book.Title, StringComparison.OrdinalIgnoreCase)))
            throw new LibraryException(409, "Book already exists");
        books.Add(book);
        return true;
    }

    public Task<bool> BorrowBookAsync(int bookId)
    {
        return null;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var deleteResponse = await this.bookRepository.DeleteByIdAsync(id);
        if(deleteResponse)
            return true;
        throw new LibraryException(404, "Book is notu found");
    }

    public async Task<IEnumerable<BookForResultDto>> GetAllAsync()
    {
        
        var books = await this.bookRepository.RetrievAllAsync();
        if (books is null || !books.Any())
            throw new LibraryException(404, "Books not found");
        var mappedBooks = books.Select(b => new BookForResultDto()
        {
            Title = b.Title,
            Category = b.Category,
            IsAvaiable = b.IsAvaiable,
        });
        return mappedBooks;
            
    }

    public async Task<BookForResultDto> GetByIdAsync(int id)
    {
        var book = await this.bookRepository.RetrievByIdAsync(id);
        if (book is null)
            throw new LibraryException(404, "Book not found");
        var mappedBook = new BookForResultDto()
        {
            Title = book.Title,
            Category = book.Category,
            IsAvaiable = book.IsAvaiable,

        };
        return mappedBook;
    }

    public async Task<bool> IsAvaibleAsync(int bookId)
    {
        var book = await this.bookRepository.RetrievByIdAsync(bookId);
        if (book is null)
            throw new LibraryException(404, "Book not found");
        return true;
    }

    public async Task<List<BookForSearchByAuthorDto>> SearchByAuthorAsync(string author)
    {
        var books = await this.bookRepository.RetrievAllAsync();
        if (!books.Any())
            throw new LibraryException(404, "Books not found");

        var mappedBooks = books
        .Where(book => book.Author == author)
        .Select(book => new BookForSearchByAuthorDto
        {
            Title = book.Title,
            IsAvaible = book.IsAvaiable
        })
        .ToList();
        return mappedBooks;
    }

    public async Task<List<BookForSearchByTitleDto>> SearchByTitleAsync(string title)
    {
        var books = await this.bookRepository.RetrievAllAsync();
        if (!books.Any())
            throw new LibraryException(404, "Books not found");
        var mappedBooks = books
            .Where (book => book.Title == title)
            .Select(book => new BookForSearchByTitleDto
            {
                Author = book.Author,
                IsAvaiable = book.IsAvaiable
            })
            .ToList();

        return mappedBooks;
    }

    public async Task<bool> UpdateAsync(int id,BookForUpdateDto book)
    {
        var bookk = await this.bookRepository.RetrievByIdAsync(id);
        if (bookk is null)
            throw new LibraryException(404, "Book not found");
        var mappedBook = new Book()
        {
            Title = bookk.Title,
            Author = bookk.Author,
            IsAvaiable = bookk.IsAvaiable
                       
        };

        this.bookRepository.UpdateAsync(mappedBook);
        return true;
    }
}
