using MediatR;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BuildingBlocks.CQRS
{
    public interface ICommand : ICommand<Unit>
    {
    }   
    public interface ICommand<out TResponse>: IRequest<TResponse>
    {

    }
}
