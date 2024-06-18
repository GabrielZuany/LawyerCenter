using API.Repository.Interfaces;
using API.Model;
using Microsoft.EntityFrameworkCore;
using API.Infra;

namespace API.Repository
{
    public class ClientLawyerRepository : IClientLawyerRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public async Task<IEnumerable<ClientLawyer>> GetAll(){
            return await _context.ClientLawyers.ToListAsync();
        }
        public async Task<IEnumerable<ClientLawyer>> GetByClientId(Guid id){
            return await _context.ClientLawyers.Where(cl => cl.ClientId == id).ToListAsync();
        }
        public async Task<IEnumerable<ClientLawyer>> GetByLawyerId(Guid id){
            return await _context.ClientLawyers.Where(cl => cl.LawyerId == id).ToListAsync();
        }
        public async Task<ClientLawyer> Create(ClientLawyer clientLawyer){
            _context.Add(clientLawyer);
            await _context.SaveChangesAsync();
            return clientLawyer;
        }
        public async Task<ClientLawyer> Delete(Guid id){
            var clientLawyer = await _context.ClientLawyers.FirstOrDefaultAsync(cl => cl.Id == id);
            if (clientLawyer == null)
                return null;
            _context.Remove(clientLawyer);
            await _context.SaveChangesAsync();
            return clientLawyer;
        }
    }
}