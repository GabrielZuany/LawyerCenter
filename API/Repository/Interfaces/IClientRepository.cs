using API.Model;

namespace API.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task Create(Client client);
        Task<Client?> Get(string? email, string? cpf, string password);
        Task Update(Client client);
        Task Delete(Client client);
    }
}