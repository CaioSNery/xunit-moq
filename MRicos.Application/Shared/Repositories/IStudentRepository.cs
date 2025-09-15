using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRicos.Application.Shared.Repositories
{
    public interface IStudentRepository
    {
        Task<bool> VerifyEmailExistsAsync(string email);
    }
}