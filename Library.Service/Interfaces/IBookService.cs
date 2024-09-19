namespace Library.Service.Interfaces;
using Library.Domain.Entities;
using Library.Service.DTOs.Books;

public interface IBookService
{
    public Task<bool> AddAsync(Book book);
    public Task<bool> DeleteByIdAsync(int id);
    public Task<BookForResultDto> GetByIdAsync(int id);
    public Task<IEnumerable<BookForResultDto>> GetAllAsync();
    public Task<IEnumerable<BookForUpdateDto>> UpdateAsync(int id, BookForUpdateDto book);
    public Task<List<BookForSearchByTitleDto>> SearchByTitleAsync(string title); 
    public Task<List<BookForSearchByAuthorDto>> SearchByAuthorAsync(string author);
    public Task<bool> IsAvaibleAsync(int bookId);
    public Task<bool> BorrowBookAsync(int bookId);
}
