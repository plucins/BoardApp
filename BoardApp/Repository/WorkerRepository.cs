using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardApp.Context;
using BoardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardApp.Repository
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly BoardContext _context;

        public WorkerRepository(BoardContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Worker>> GetAll()
        {
            return await _context.Workers.ToListAsync();
        }

        public async Task<Worker> GetById(long id)
        {
            return await _context.Workers
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public Task<Worker> Add(Worker entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Worker> Update(Worker entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}