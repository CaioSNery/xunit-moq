using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRicos.Application.Shared.Abstractions;
using MRicos.Application.Shared.Results;
using MRicos.Application.UseCases.Edit;

namespace MRicos.Application.UseCases.Create
{
    public sealed record Command(string FirstName,
        string LastName,
        string Cpf,
        string Email,
        string Password,
        string Street,
        string City,
        string State,
        string ZipCode) : ICommand<Response>
    {

    }
}