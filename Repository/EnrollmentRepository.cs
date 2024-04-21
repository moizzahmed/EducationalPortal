using EducationalPortal.Models;
using EducationalPortal.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EducationalPortal.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;
        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse> Add(Enrollment enrollment)
        {
            var resp = new RepositoryResponse();

            _context.Enrollments.Add(enrollment);

            await _context.SaveChangesAsync();

            resp.Status = true;
            resp.Data = enrollment;

            return resp;
        }

        public async Task<RepositoryResponse> Delete(Enrollment enrollment)
        {
            var dbEnr = await _context.Enrollments
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(u => u.EnrollmentId == enrollment.EnrollmentId);

            if (dbEnr == null)
            {
                return new RepositoryResponse
                {
                    Status = false,
                    Data = "Enrollment not found."
                };
            }

            dbEnr = await _context.Enrollments.FindAsync(enrollment);
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return new RepositoryResponse
            {
                Status = true,
                Data = "Enrollment deleted successfully."
            };
        }

        public async Task<IEnumerable<Enrollment>> GetAll()
        {
            return await _context.Enrollments.ToListAsync();
        }

        public async Task<Enrollment> GetById(int id)
        {
            return await _context.Enrollments.FindAsync(id);
        }

        public async Task<RepositoryResponse> Update(Enrollment enrollment)
        {
            var dbEnr = await _context.Enrollments
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(u => u.EnrollmentId == enrollment.EnrollmentId);

            if (dbEnr == null)
            {
                return new RepositoryResponse
                {
                    Status = false,
                    Data = "Enrollment not found."
                };
            }

            dbEnr = await _context.Enrollments.FindAsync(enrollment.EnrollmentId);
            _context.Enrollments.Update(dbEnr);
            await _context.SaveChangesAsync();

            return new RepositoryResponse
            {
                Status = true,
                Data = enrollment
            };
        }
    }
}
