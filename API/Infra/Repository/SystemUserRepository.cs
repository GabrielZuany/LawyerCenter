using Microsoft.EntityFrameworkCore;
using API.Model;
using API.Repository.Interfaces;

namespace API.Infra.Repository
{
    class SystemUserRepository : ISystemUserRepository
    {
        private readonly ConnectionContext _context;

        public SystemUserRepository(ConnectionContext context)
        {
            _context = context;
        }
        public void Create(SystemUser sysUser)
        {
            _context.Add(sysUser);
            _context.SaveChanges();
        }
        public SystemUser? Get(string email)
        {
            return _context.SystemUsers.FirstOrDefault(s => s.Email == email);
        }
        public void Update(SystemUser sysUser)
        {
            _context.Update(sysUser);
            _context.SaveChanges();
        }
        public void Delete(SystemUser sysUser)
        {
            _context.Remove(sysUser);
            _context.SaveChanges();
        }
    }
}