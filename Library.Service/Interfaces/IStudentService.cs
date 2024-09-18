using Library.Domain.Entities;
using Library.Service.DTOs.Students;

namespace Library.Service.Interfaces;

public interface IStudentService
{
    public Task<bool> AddAsync(Student student);
    public Task<bool> DeleteByIdAsync(int id);
    public Task<StudentForResultDto> GetByIdAsync(int id);
    public Task<StudentForResultDto> GetAllAsync();
    public Task<StudentForUpdateDto> UpdateAsync(Student student);
}
