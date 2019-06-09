using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardApp.Context;
using BoardApp.Models;
using BoardApp.Models.dto;
using BoardApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoardApp.Services
{
    public class RepairCaseService
    {

        private readonly RepairCaseRepository _repairCaseRepository;

        public RepairCaseService(RepairCaseRepository repairCaseRepository)
        {
            _repairCaseRepository = repairCaseRepository;
        }


        public async Task<RepairCase> RegisterRepairCase(RepairCaseDto dto)
        {
          return await _repairCaseRepository.Add(RepairCase.Create(dto));
        }

        public async Task<IEnumerable<RepairCase>> GetAllRepairCases()
        {
            return await _repairCaseRepository.GetAll();
        }

        public async Task<ActionResult<RepairCase>> UpdateRepairCase(RepairCase repairCase)
        {
            return await _repairCaseRepository.Update(repairCase);
        }
    }
}