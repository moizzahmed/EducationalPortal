using EducationalPortal.Models;

namespace EducationalPortal.Repository.Interface
{
    public interface IProgramClassRepository
    {
        Task<IEnumerable<ProgramClass>> GetAll();
        Task<ProgramClass> GetById(int id);
        Task<RepositoryResponse> Add(ProgramClass pClass);
        Task<RepositoryResponse> Update(ProgramClass pClass);
        Task<RepositoryResponse> Delete(ProgramClass pClass);
    }
}
