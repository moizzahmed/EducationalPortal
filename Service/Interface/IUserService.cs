using EducationalPortal.Models;

namespace EducationalPortal.Service.Interface
{
    public interface IUserService
    {
        Task<ServiceResponse> Login(LoginModel login);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(string id);
        Task<ServiceResponse> Add(User user);
        Task<ServiceResponse> Update(User user);
        Task<ServiceResponse> Delete(User user);
    }
}
