using EducationalPortal.Models;

namespace EducationalPortal.Repository.Interface
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetAll();
        Task<Enrollment> GetById(int id);
        Task<RepositoryResponse> Add(Enrollment enrollment);
        Task<RepositoryResponse> Update(Enrollment enrollment);
        Task<RepositoryResponse> Delete(Enrollment enrollment);
    }
}
