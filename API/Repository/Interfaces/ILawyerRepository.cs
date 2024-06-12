using API.Model;

namespace API.Repository.Interfaces
{
    public interface ILawyerRepository
    {
        Task Create(Lawyer lawyer);
        Task<Lawyer?> Get(string? email, string? cpf, string password);
        Task Update(Lawyer lawyer);
        Task Delete(Lawyer lawyer);
    }
}