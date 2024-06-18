using API.Model;

namespace API.Repository.Interfaces
{
    public interface ILawyerRepository
    {
        Task Create(Lawyer lawyer);
        Task<Lawyer?> Login(string? email, string? cpf, string password);
        // Task<IEnumerable<Lawyer>> GetPage(int skip, int take);
        // Task<Lawyer> GetById(Guid id);
        Task Update(Lawyer lawyer);
        Task Delete(Lawyer lawyer);
    }
}