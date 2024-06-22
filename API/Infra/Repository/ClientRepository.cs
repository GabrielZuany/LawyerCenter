using API.Repository.Interfaces;
using API.Model;
using Microsoft.EntityFrameworkCore;
using API.Infra;

namespace API.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public Task Create(Client client){
            _context.Add(client);
            return _context.SaveChangesAsync();
        }
        public async Task<Client?> Get(string? email, string? cpf, string password){
            if (email == null)
                return await _context.Clients.FirstOrDefaultAsync(c => c.Cpf == cpf && c.Password == password);
            if (cpf == null)
                return await _context.Clients.FirstOrDefaultAsync(c => c.Email == email && c.Password == password);
            return await _context.Clients.FirstOrDefaultAsync(c => c.Cpf == cpf && c.Email == email && c.Password == password);
        }
        public async Task Update(Client client){
            _context.Update(client);
            await _context.SaveChangesAsync();
        }
        public Task Delete(Client client){
            _context.Remove(client);
            return _context.SaveChangesAsync();
        }
    }
}