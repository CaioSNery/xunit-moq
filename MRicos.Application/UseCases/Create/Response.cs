
using MRicos.Application.Shared.Abstractions;

namespace MRicos.Application.UseCases.Create
{
    public sealed record Response(Guid Id, string Email) : ICommandResponse;

}