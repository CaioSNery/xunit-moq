using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MRicos.Application.Shared.Results;

namespace MRicos.Application.Shared.Abstractions
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
        where TCommand : ICommand
    {

    }

    public interface ICommandHandler<in TCommand, TCommandResponse> : IRequestHandler<TCommand, TCommandResponse>
        where TCommand : ICommand<TCommandResponse>
        where TCommandResponse : ICommandResponse
    {

    }
}