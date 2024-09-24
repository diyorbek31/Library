using Library.Data.IRepositories;
using Library.Domain.Entities;
using Library.Service.Interfaces;
using Library.Service.DTOs.Teachers;
using Library.Data.Repositories;
using Library.Service.Exceptions;

namespace Library.Service.Services;

public class TeacherService : ITecharService
{
    IRepository<Teacher> teacherRepository = new Repository<Teacher>();

    public async Task<bool> AddAsync(Teacher teacher)
    {
        var teachers = await this.teacherRepository.RetrievAllAsync();
        if (teachers.Any(t => t.Email.Equals(teacher.Email, StringComparison.OrdinalIgnoreCase)))
            throw new LibraryException(409, "User already exists");

        await this.teacherRepository.InsertAsync(teacher);
        return true;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var deleteResponse = await this.teacherRepository.DeleteByIdAsync(id);
        if(deleteResponse)
            return true;
        throw new LibraryException(404, "User not found");

    }

    public async Task<IEnumerable<TeacherForResultDto>> GetAllAsync()
    {
        var teachers = await this.teacherRepository.RetrievAllAsync();
        if (!teachers.Any())
            throw new LibraryException(404, "Users not found ");
        var mappedTeachers = teachers.Select(t => new TeacherForResultDto()
        {
            FirstName = t.FirstName,
            LastName = t.LastName,
            PhoneNumber = t.PhoneNumber,

        }).ToList();

        return mappedTeachers;
    }

    public async Task<TeacherForResultDto> GetByIdAsync(int id)
    {
        var teacher = await this.teacherRepository.RetrievByIdAsync(id);
        if (teacher is null)
            throw new LibraryException(404, "User not found");

        var mappedTeacher = new TeacherForResultDto()
        {
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            PhoneNumber = teacher.PhoneNumber,
        };

        return mappedTeacher;

    }

    public async Task<bool> UpdateAsync(int id,TeacherForUpdateDto teacher)
    {
        var teacherUpd = await this.teacherRepository.RetrievAllAsync();
        if (teacher is null)
            throw new LibraryException(404, "Users not found");

        var mappedteacher = new Teacher()
        {
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            PhoneNumber = teacher.PhoneNumber,
            Email = teacher.Email,

        };

        this.teacherRepository.UpdateAsync(mappedteacher);
        return true;
    }
}
