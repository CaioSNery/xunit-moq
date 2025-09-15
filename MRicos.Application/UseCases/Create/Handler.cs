
using System;
using System.Threading;
using System.Threading.Tasks;

using MRicos.Application.Shared.Abstractions;
using MRicos.Application.Shared.Repositories;

namespace MRicos.Application.UseCases.Create
{
    public sealed class Handler(IStudentRepository studentRepository) : ICommandHandler<Command, Response>
    {
        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            //verificar se o email esta cadastrado
            var emailExists = await studentRepository.VerifyEmailExistsAsync(request.Email);
            if (emailExists)
            {
                throw new Exception("O email já está cadastrado.");
            }

            //gerar os valuesobjects
            //gerar a entidade
            //salvar no banco
            //retornar o response
            return new Response(Guid.NewGuid(), request.Email);

        }
    }
}