using EducationalPortal.Models;
using EducationalPortal.Repository;
using EducationalPortal.Repository.Interface;
using EducationalPortal.Service.Interface;

namespace EducationalPortal.Service
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<ServiceResponse> Add(Enrollment enrollment)
        {
            var response = await _enrollmentRepository.Add(enrollment);
            return new ServiceResponse() { Status = response.Status, Data = response.Data };
        }

        public async Task<ServiceResponse> Delete(Enrollment enrollment)
        {
            var response = await _enrollmentRepository.Delete(enrollment);
            return new ServiceResponse() { Status = response.Status, Data = response.Data };
        }

        public async Task<IEnumerable<Enrollment>> GetAll()
        {
            return await _enrollmentRepository.GetAll();
        }

        public async Task<Enrollment> GetById(int id)
        {
            return await _enrollmentRepository.GetById(id);
        }

        public async Task<ServiceResponse> Update(Enrollment enrollment)
        {
            var response = await _enrollmentRepository.Update(enrollment);
            return new ServiceResponse() { Status = response.Status, Data = response.Data };
        }
    }
}
