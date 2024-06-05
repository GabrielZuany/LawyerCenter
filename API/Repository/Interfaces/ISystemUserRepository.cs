using API.Model;

namespace API.Repository.Interfaces
{
    public interface ISystemUserRepository
    {
        void Create(SystemUser sysUser);
        SystemUser? Get(string email);
        void Update(SystemUser sysUser);
        void Delete(SystemUser sysUser);
    }
}