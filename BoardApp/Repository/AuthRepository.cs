using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardApp.Context;
using BoardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardApp.Repository
{
    public class AuthRepository : IAuthRepository
    {

        private readonly BoardContext _context;

        public AuthRepository(BoardContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<ApplicationUser>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ApplicationUser> GetById(long id)
        {
            return await _context.ApplicationUsers.Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<ApplicationUser> Add(ApplicationUser entity)
        {
            await _context.ApplicationUsers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return await GetById(entity.Id);
        }

        public Task<ApplicationUser> Update(ApplicationUser entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ApplicationUser> GetByEmail(string Email)
        {
            return await _context.ApplicationUsers.Where(x => x.UserEmail == Email)
                .SingleOrDefaultAsync();
        }
    }
}