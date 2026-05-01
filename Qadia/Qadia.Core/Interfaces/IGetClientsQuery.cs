using Qadia.Core.Dtos;
using System.Collections.Generic;

namespace Qadia.Core.Interfaces
{
    public interface IGetClientsQuery
    {
        IEnumerable<ClientDto> Execute();
    }
}
