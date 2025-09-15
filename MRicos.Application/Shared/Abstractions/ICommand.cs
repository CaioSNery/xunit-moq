using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MRicos.Application.Shared.Results;
using MRicos.Application.UseCases.Create;

namespace MRicos.Application.Shared.Abstractions
{
    public interface ICommand : IRequest<Result>;

    public interface ICommand<TCommandResponse> : IRequest<TCommandResponse> where TCommandResponse : ICommandResponse
    {
    }



}