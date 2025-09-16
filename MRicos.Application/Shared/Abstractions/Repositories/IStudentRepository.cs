using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRicos.Domain.Accounts.Entities;

namespace MRicos.Application.Shared.Repositories
{
    public interface IStudentRepository
    {
        Task<bool> VerifyEmailExistsAsync(string email);

        Task SaveAsync(Student student);
    }
}