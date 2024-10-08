﻿using Library.Domain.Entities;
using Library.Service.DTOs.Students;

namespace Library.Service.Interfaces;

public interface IStudentService
{
    public Task<bool> AddAsync(Student student);
    public Task<bool> DeleteByIdAsync(int id);
    public Task<StudentForResultDto> GetByIdAsync(int id);
    public Task<IEnumerable<StudentForResultDto>> GetAllAsync();
    public Task<bool> UpdateAsync(int id ,StudentForUpdateDto student);
    public Task<bool> BorrowBookAsync(int bookId);
}
