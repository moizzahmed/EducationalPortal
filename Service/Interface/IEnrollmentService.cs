using EducationalPortal.Models;

namespace EducationalPortal.Service.Interface
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<Enrollment>> GetAll();
        Task<Enrollment> GetById(int id);
        Task<ServiceResponse> Add(Enrollment enrollment);
        Task<ServiceResponse> Update(Enrollment enrollment);
        Task<ServiceResponse> Delete(Enrollment enrollment);
    }
}
