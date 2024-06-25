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

        public async Task<IEnumerable<Lawyer>> GetFiltered(int skip, int take, string? category, string? state)
        {
            if (category == null && state == null)
                return await _context
                                .Lawyers
                                .Skip(skip)
                                .Take(take)
                                .ToListAsync();
            if (category == null)
                return await _context
                                .Lawyers
                                .Where(l => l.State == state)
                                .Skip(skip)
                                .Take(take)
                                .ToListAsync();
            LawyerCategory lawyerCategory = await _context.LawyerCategories.FirstOrDefaultAsync(lc => lc.Alias == category);
            if (lawyerCategory == null)
                return null;
            Guid categoryId = lawyerCategory.Id;
            if (state == null)
                return await _context
                                .Lawyers
                                .Where(l => l.LawyerCategoryId == categoryId)
                                .Skip(skip)
                                .Take(take)
                                .ToListAsync();
            return await _context
                            .Lawyers
                            .Where(l => l.LawyerCategoryId == categoryId && l.State == state)
                            .Skip(skip)
                            .Take(take)
                            .ToListAsync();
        }
    }
}