
using System;
using System.Threading;
using System.Threading.Tasks;

using MRicos.Application.Shared.Abstractions;
using MRicos.Application.Shared.Repositories;
using MRicos.Application.Shared.Results;
using MRicos.Domain.Accounts.Entities;
using MRicos.Domain.Accounts.Entities.ValueObjects;
using MRicos.Domain.ValueObjects;

namespace MRicos.Application.UseCases.Create
{
    public sealed class Handler(IStudentRepository studentRepository) : ICommandHandler<Command, Response>
    {
        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            //verificar se o email esta cadastrado
            var emailExists = await studentRepository.VerifyEmailExistsAsync(request.Email);
            if (emailExists)
            return Result.Failure<Response>(new Error(Code:"400", Message:"Email already registered")).Value!;

            //gerar os valuesobjects
            var name =  Name.Create(request.FirstName, request.LastName);
            var cpf = Cpf.Create(request.Cpf);
            var email = Email.Create(request.Email);
            var address = Address.Create(request.Street, request.City, request.State, request.ZipCode);
            var password = Password.Create(request.Password);

            //gerar a entidade
            var student = Student.Create(name, email, cpf, password, address, new Domain.Shared.Abstractions.DateTimeProvider());
            //salvar no banco
            await studentRepository.SaveAsync(student);
            //retornar o response
            
            return new Response(Guid.NewGuid(), request.Email);

        }
    }
}