using API.Infra;
using API.Model;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Infra.Repository
{
    public class LawyerCategoryRepository : ILawyerCategoryRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public Task Create(LawyerCategory lawyerCategory){
            _context.Add(lawyerCategory);
            return _context.SaveChangesAsync();
        }
        public async Task<LawyerCategory?> Get(int typeInt){
            return await _context.LawyerCategories.FirstOrDefaultAsync(l => l.TypeInt == typeInt);
        }
        public async Task<LawyerCategory?> Get(string alias){
            return await _context.LawyerCategories.FirstOrDefaultAsync(l => l.Alias == alias);
        }
        public async Task Update(LawyerCategory lawyerCategory){
            _context.Update(lawyerCategory);
            await _context.SaveChangesAsync();
        }
        public Task Delete(LawyerCategory lawyerCategory){
            _context.Remove(lawyerCategory);
            return _context.SaveChangesAsync();
        }
    }
}