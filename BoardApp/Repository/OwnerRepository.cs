using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardApp.Context;
using BoardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        
        private readonly BoardContext _context;

        public OwnerRepository(BoardContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Owner>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Owner> GetById(long id)
        {
            return await _context.Owners.Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<Owner> Add(Owner entity)
        {
            await _context.Owners.AddAsync(entity);
            await _context.SaveChangesAsync();
            return await GetById(entity.Id);
        }

        public Task<Owner> Update(Owner entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Owner> FindOwnerPresentByAllData(Owner entity)
        {
            return await _context.Owners.Where(x =>
                    x.Name.Equals(entity.Name) && x.LastName.Equals(entity.LastName) &&
                    x.PhoneNumber.Equals(entity.PhoneNumber))
                .SingleOrDefaultAsync();
        }
    }
}