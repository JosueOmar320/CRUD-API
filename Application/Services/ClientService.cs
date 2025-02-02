using Application.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly AppDbContext _context;

        public ClientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateClientAsync(Client client, CancellationToken cancellationToken = default)
        {
            await _context.Clients.AddAsync(client, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return client.ClientId;
        }

        public async Task<List<Client>> GetAllClientsAsync(CancellationToken cancellationToken = default)
        {
            var data = await _context.Clients.ToListAsync(cancellationToken);

            return data;
        }

        public async Task<Client> GetClientByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var data = await _context.Clients.FirstOrDefaultAsync(x => x.ClientId.Equals(id), cancellationToken);

            return data;
        }
    }
}
