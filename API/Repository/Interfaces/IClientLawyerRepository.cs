using API.Model;

namespace API.Repository.Interfaces
{
    public interface IClientLawyerRepository
    {
        Task<IEnumerable<ClientLawyer>> GetAll();
        Task<IEnumerable<ClientLawyer>> GetByClientId(Guid id);
        Task<IEnumerable<ClientLawyer>> GetByLawyerId(Guid id);
        Task<ClientLawyer> Create(ClientLawyer clientLawyer);
        Task<ClientLawyer> Delete(Guid id);
    }
}