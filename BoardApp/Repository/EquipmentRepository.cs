using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using BoardApp.Context;
using BoardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardApp.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        
        private readonly BoardContext _context;

        public EquipmentRepository(BoardContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipment>> GetAll()
        {
            var eqs = await _context.Equipments.ToListAsync();
            eqs.ForEach(e => { _context.Entry(e).Reference(r => r.Owner).Load();});
            return eqs;
        }

        public async Task<Equipment> GetById(long id)
        {
            var eq = await _context.Equipments
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            await _context.Entry(eq).Reference(x => x.Owner).LoadAsync();
            return eq;
        }

        public async Task<Equipment> Add(Equipment entity)
        {
            if (entity.Owner != null)
            {
                await _context.Equipments
                    .Include(x => x.Owner)
                    .FirstAsync();
            }

            await _context.Equipments.AddAsync(entity);
            await _context.SaveChangesAsync();
            return await GetById(entity.Id);
        }

        public Task<Equipment> Update(Equipment entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}