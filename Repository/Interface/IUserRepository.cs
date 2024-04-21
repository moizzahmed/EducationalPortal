using EducationalPortal.Models;

namespace EducationalPortal.Repository.Interface
{
    public interface IUserRepository
    {

        Task<RepositoryResponse> Login(LoginModel login);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(string id);
        Task<RepositoryResponse> Add(User user);
        Task<RepositoryResponse> Update(User user);
        Task<RepositoryResponse> Delete(User user);
    }
}
