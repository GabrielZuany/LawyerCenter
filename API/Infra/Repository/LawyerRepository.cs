using API.Infra;
using API.Model;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Infra.Repository
{
    public class LawyerRepository : ILawyerRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public Task Create(Lawyer lawyer){
            _context.Add(lawyer);
            return _context.SaveChangesAsync();
        }
        public async Task<Lawyer?> Login(string? email, string? cpf, string password){
            if (email == null)
                return await _context.Lawyers.FirstOrDefaultAsync(l => l.Cpf == cpf && l.Password == password);
            if (cpf == null)
                return await _context.Lawyers.FirstOrDefaultAsync(l => l.Email == email && l.Password == password);
            return await _context.Lawyers.FirstOrDefaultAsync(l => l.Cpf == cpf && l.Email == email && l.Password == password);
        }
        public async Task Update(Lawyer lawyer){
            _context.Update(lawyer);
            await _context.SaveChangesAsync();
        }
        public Task Delete(Lawyer lawyer){
            _context.Remove(lawyer);
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lawyer>> GetPage(int skip, int take)
        {
            return await _context
                            .Lawyers
                            .Skip(skip)
                            .Take(take)
                            .ToListAsync();
        }

        public async Task<Lawyer?> GetById(Guid id)
        {
            return await _context.Lawyers.FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}