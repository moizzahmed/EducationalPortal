using EducationalPortal.Models;
using EducationalPortal.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EducationalPortal.Repository
{
    public class ProgramClassRepository : IProgramClassRepository
    {
        private readonly ApplicationDbContext _context;
        public ProgramClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse> Add(ProgramClass pClass)
        {
            var resp = new RepositoryResponse();

            _context.Classes.Add(pClass);

            await _context.SaveChangesAsync();

            resp.Status = true;
            resp.Data = pClass;

            return resp;
        }

        public async Task<RepositoryResponse> Delete(ProgramClass pClass)
        {
            var dbclass = await _context.Classes
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(u => u.ClassId == pClass.ClassId);

            if (dbclass == null)
            {
                return new RepositoryResponse
                {
                    Status = false,
                    Data = "Class not found."
                };
            }

            dbclass = await _context.Classes.FindAsync(pClass.ClassId);
            _context.Classes.Remove(dbclass);
            await _context.SaveChangesAsync();

            return new RepositoryResponse
            {
                Status = true,
                Data = "Class deleted successfully."
            };
        }

        public async Task<IEnumerable<ProgramClass>> GetAll()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<ProgramClass> GetById(int id)
        {
            return await _context.Classes.FindAsync(id);
        }

        public async Task<RepositoryResponse> Update(ProgramClass pClass)
        {
            var dbClass = await _context.Classes
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(u => u.ClassId == pClass.ClassId);

            if (dbClass == null)
            {
                return new RepositoryResponse
                {
                    Status = false,
                    Data = "Class not found."
                };
            }

            dbClass = await _context.Classes.FindAsync(pClass.ClassId);
            _context.Classes.Update(dbClass);
            await _context.SaveChangesAsync();

            return new RepositoryResponse
            {
                Status = true,
                Data = pClass
            };
        }
    }
}
