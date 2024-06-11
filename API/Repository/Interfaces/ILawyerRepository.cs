using API.Model;

namespace API.Repository.Interfaces
{
    public interface ILawyerRepository
    {
        void Create(Lawyer lawyer);
        Lawyer? Get(string email, string cpf, string password);
        void Update(Lawyer lawyer);
        void Delete(Lawyer lawyer);

    }
}