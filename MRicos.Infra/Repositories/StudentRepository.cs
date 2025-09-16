using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MRicos.Application.Shared.Repositories;
using MRicos.Domain.Accounts.Entities;
using MRicos.Infra.Data;

namespace MRicos.Infra.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context) => _context = context;

        public async Task SaveAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> VerifyEmailExistsAsync(string email)
        {
            return await _context.Students.AsNoTracking().AnyAsync(s => s.Email == email);
        }
    }
}