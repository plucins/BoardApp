using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardApp.Context;
using BoardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardApp.Repository
{
    public class RepairCaseRepository : IRepairCaseRepository
    {
        private readonly BoardContext _context;
        private readonly WorkerRepository _workerRepository;
        private readonly EquipmentRepository _equipmentRepository;

        public RepairCaseRepository(BoardContext context, WorkerRepository workerRepository,
            EquipmentRepository equipmentRepository)
        {
            _context = context;
            _workerRepository = workerRepository;
            _equipmentRepository = equipmentRepository;
        }


        public async Task<IEnumerable<RepairCase>> GetAll()
        {
            var cases = await _context.RepairCases.ToListAsync();
            cases.ForEach(c => { _context.Entry(c).Reference(r => r.Worker).Load(); });
            cases.ForEach(c =>
            {
                _context.Entry(c).Reference(r => r.Equipment).Load();
                if (c.Equipment != null)
                {
                    _context.Entry(c.Equipment).Reference(x => x.Owner).Load();
                }

                
            });
            return cases;
        }

        public async Task<RepairCase> GetById(long id)
        {
            var repairCase = await _context.RepairCases
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            await _context.Entry(repairCase).Reference(x => x.Worker).LoadAsync();
            await _context.Entry(repairCase).Reference(x => x.Equipment).LoadAsync();
            return repairCase;
        }

        public async Task<RepairCase> Add(RepairCase entity)
        {
            entity.RegistrationTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
//            await _context.RepairCases
//                .Include(x => x.Worker)
//                .Include(x => x.Equipment)
//                .FirstAsync();
            await _context.RepairCases.AddAsync(entity);
            await _context.SaveChangesAsync();
            return await GetById(entity.Id);
        }

        public async Task<RepairCase> Update(RepairCase entity)
        {
            var caseToUpdate = GetById(entity.Id).Result;

            if (caseToUpdate != null)
            {
                caseToUpdate.Title = entity.Title ?? caseToUpdate.Title;
                caseToUpdate.Description = entity.Description ?? caseToUpdate.Description;
                caseToUpdate.Status = entity.Status;
                caseToUpdate.LastUpdate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

                if (entity.Worker != null && entity.Worker.Id != 0)
                {
                    caseToUpdate.Worker = await _workerRepository.GetById(entity.Worker.Id);
                }

                if (entity.Equipment != null && entity.Equipment.Id != 0)
                {
                    caseToUpdate.Equipment = await _equipmentRepository.GetById(entity.Equipment.Id);
                }

                await _context.SaveChangesAsync();
            }


            return await GetById(caseToUpdate.Id) ?? entity;
        }

        public async Task Delete(long id)
        {
            var caseToDelete = GetById(id).Result;
            if (caseToDelete != null)
            {
                _context.RepairCases.Remove(caseToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}