using EducationalPortal.Models;
using EducationalPortal.Repository.Interface;
using EducationalPortal.Service.Interface;

namespace EducationalPortal.Service
{
    public class ProgramClassService : IProgramClassService
    {
        private readonly IProgramClassRepository _programClassRepository;

        public ProgramClassService(IProgramClassRepository programClassRepository)
        {
            _programClassRepository = programClassRepository;
        }

        public async Task<ServiceResponse> Add(ProgramClass pClass)
        {
            var response = await _programClassRepository.Add(pClass);
            return new ServiceResponse() { Status = response.Status, Data = response.Data };
        }

        public async Task<ServiceResponse> Delete(ProgramClass pClass)
        {
            var response = await _programClassRepository.Delete(pClass);
            return new ServiceResponse() { Status = response.Status, Data = response.Data };
        }

        public async Task<IEnumerable<ProgramClass>> GetAll()
        {
            return await _programClassRepository.GetAll();
        }

        public async Task<ProgramClass> GetById(int id)
        {
            return await _programClassRepository.GetById(id);
        }

        public async Task<ServiceResponse> Update(ProgramClass pClass)
        {
            var response = await _programClassRepository.Update(pClass);
            return new ServiceResponse() { Status = response.Status, Data = response.Data };
        }
    }
}
