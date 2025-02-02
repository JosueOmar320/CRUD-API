using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientService
    {
        Task<List<Client>> GetAllClientsAsync(CancellationToken cancellationToken = default);
        Task<Client> GetClientByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<int> CreateClientAsync(Client client, CancellationToken cancellationToken = default);
    }
}
