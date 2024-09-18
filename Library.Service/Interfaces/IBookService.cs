namespace Library.Service.Interfaces;
using Library.Domain.Entities;
using Library.Service.DTOs.Books;

public interface IBookService
{
    public Task<bool> AddAsync(Book book);
    public Task<bool> DeleteByIdAsync(int id);
    public Task<BookForResultDto> GetByIdAsync(int id);
    public Task<BookForResultDto> GetAllAsync();
    public Task<BookForUpdateDto> UpdateAsync(Book book);
}
