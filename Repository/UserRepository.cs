using EducationalPortal.Models;
using EducationalPortal.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EducationalPortal.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RepositoryResponse> Add(User user)
        {
            var resp = new RepositoryResponse();

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            resp.Status = true;
            resp.Data = user;

            return resp;
        }
        public async Task<RepositoryResponse> Delete(User user)
        {
            var dbUser = await _context.Users
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(u => u.Id == user.Id);

            if (dbUser == null)
            {
                return new RepositoryResponse
                {
                    Status = false,
                    Data = "User not found."
                };
            }

            dbUser = await _context.Users.FindAsync(user.Id);
            _context.Users.Remove(dbUser);
            await _context.SaveChangesAsync();

            return new RepositoryResponse
            {
                Status = true,
                Data = "User deleted successfully."
            };
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task<User> GetById(string id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<RepositoryResponse> Login(LoginModel login)
        {
            var dbUser = await _context.Users
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(u => u.username == login.username);

            if (dbUser == null)
            {
                return new RepositoryResponse
                {
                    Status = false,
                    Data = "User not found."
                };
            }

            if (dbUser != null && dbUser.PasswordHash == Helper.Hash.CreateSHA256(login.password))
            {
                return new RepositoryResponse
                {
                    Status = true,
                    Data = dbUser
                };
            }

            return new RepositoryResponse
            {
                Status = false,
                Data = "Other Error"
            };
        }
        public async Task<RepositoryResponse> Update(User user)
        {
            var dbUser = await _context.Users
                                       .FirstOrDefaultAsync(u => u.Id == user.Id);

            if (dbUser == null)
            {
                return new RepositoryResponse
                {
                    Status = false,
                    Data = "User not found."
                };
            }

            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Email = user.Email;
            dbUser.UserName = user.UserName;

            await _context.SaveChangesAsync();

            return new RepositoryResponse
            {
                Status = true,
                Data = user
            };
        }
    }
}
