using API.Model;

namespace API.Repository.Interfaces
{
    public interface ILawyerRepository
    {
        Task Create(Lawyer lawyer);
        Task<Lawyer?> Login(string? email, string? cpf, string password);
        Task<IEnumerable<Lawyer>> GetPage(int skip, int take);
        Task<IEnumerable<Lawyer>> GetPageFiltered(int skip, int take, string? category, string? state);
        Task<IEnumerable<Lawyer>> GetAllFiltered(string? category, string? state);
        Task<int> CountAllFiltered(string? category, string? state);
        Task<Lawyer?> GetById(Guid id);
        Task Update(Lawyer lawyer);
        Task Delete(Lawyer lawyer);
    }
}