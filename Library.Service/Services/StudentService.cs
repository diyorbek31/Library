using Library.Data.IRepositories;
using Library.Data.Repositories;
using Library.Domain.Entities;
using Library.Service.DTOs.Students;
using Library.Service.Exceptions;
using Library.Service.Interfaces;

namespace Library.Service.Services;

public class StudentService : IStudentService
{
    IRepository<Student> studentRepository = new Repository<Student>();

    public async Task<bool> AddAsync(Student student)
    {
        var students = await this.studentRepository.RetrievAllAsync();
        if (students.Any(s => s.Email.Equals(student.Email, StringComparison.OrdinalIgnoreCase)))
            throw new LibraryException(404, "User already exists");
        await this.studentRepository.InsertAsync(student);
        return true;

    }

    public Task<bool> BorrowBookAsync(int bookId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var deleteResponse = await this.studentRepository.DeleteByIdAsync(id);
        if (deleteResponse)
            return true;
        throw new LibraryException(404, "User not found");

    }

    public async Task<IEnumerable<StudentForResultDto>> GetAllAsync()
    {
        var students = await this.studentRepository.RetrievAllAsync();
        if (!students.Any())
            throw new LibraryException(404, "Users not found");
        
        var mappedStudents = students.Select(s => new StudentForResultDto()
        {
            FirstName = s.FirstName,
            LastName = s.LastName,
            MembershipStatus = s.MembershipStatus,
            PhoneNumber = s.PhoneNumber,
        }).ToList();

        return mappedStudents;
    }

    public async Task<StudentForResultDto> GetByIdAsync(int id)
    {
        var student = await this.studentRepository.RetrievByIdAsync(id);
        if (student is null)
            throw new LibraryException(404, "User not found");
        var mappedStudent = new StudentForResultDto()
        {
            FirstName = student.FirstName,
            LastName = student.LastName,
            MembershipStatus = student.MembershipStatus,
            PhoneNumber = student.PhoneNumber,
        };
        return mappedStudent;
    }

    public async Task<bool> UpdateAsync(int id, StudentForUpdateDto student)
    {
        var studentUpdate = await this.studentRepository.RetrievByIdAsync(id);
        if (studentUpdate is null)
            throw new LibraryException(404, "User not found");

        var mappedStudent = new Student()
        {
            Id = studentUpdate.Id,
            Course = studentUpdate.Course,
            FirstName = studentUpdate.FirstName,
            LastName = studentUpdate.LastName,
            MembershipStatus = studentUpdate.MembershipStatus,
            PhoneNumber = studentUpdate.PhoneNumber,
            Email = studentUpdate.Email,
            CreatedAt = studentUpdate.CreatedAt,
        };
        
        this.studentRepository.UpdateAsync(mappedStudent); 
        return true;
        
    }
}
