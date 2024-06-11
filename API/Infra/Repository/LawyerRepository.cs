using API.Infra;
using API.Model;
using API.Repository.Interfaces;

namespace API.Infra.Repository
{
    public class LawyerRepository : ILawyerRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Create(Lawyer lawyer){
            _context.Add(lawyer);
            _context.SaveChanges();
        }
        public Lawyer? Get(string email, string cpf, string password){
            return _context.Lawyers.FirstOrDefault(l => l.Cpf == cpf && l.Email == email && l.Password == password);
        }
        public void Update(Lawyer lawyer){
            _context.Update(lawyer);
            _context.SaveChanges();
        }
        public void Delete(Lawyer lawyer){
            _context.Remove(lawyer);
            _context.SaveChanges();
        }
    }
}