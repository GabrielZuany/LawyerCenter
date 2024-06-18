using API.Model;

namespace API.Repository.Interfaces
{
    public interface ILawyerCategoryRepository
    {
        Task Create(LawyerCategory lawyerCategory);
        Task<LawyerCategory?> Get(int typeInt);
        Task<LawyerCategory?> Get(string alias);
        Task Update(LawyerCategory lawyerCategory);
        Task Delete(LawyerCategory lawyerCategory);
    }
}