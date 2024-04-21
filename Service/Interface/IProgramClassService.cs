using EducationalPortal.Models;

namespace EducationalPortal.Service.Interface
{
    public interface IProgramClassService
    {
        Task<IEnumerable<ProgramClass>> GetAll();
        Task<ProgramClass> GetById(int id);
        Task<ServiceResponse> Add(ProgramClass pClass);
        Task<ServiceResponse> Update(ProgramClass pClass);
        Task<ServiceResponse> Delete(ProgramClass pClass);
    }
}
