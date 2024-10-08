﻿using Library.Domain.Entities;
using Library.Service.DTOs.Teachers;

namespace Library.Service.Interfaces;

public interface ITecharService
{
    public Task<bool> AddAsync(Teacher teacher);
    public Task<bool> DeleteByIdAsync(int id);
    public Task<TeacherForResultDto> GetByIdAsync(int id);
    public Task<IEnumerable<TeacherForResultDto>> GetAllAsync();
    public Task<bool> UpdateAsync(int id,TeacherForUpdateDto teacher);
}
