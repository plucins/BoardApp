using System.Collections.Generic;
using System.Threading.Tasks;
using BoardApp.Models;
using BoardApp.Models.dto;
using BoardApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BoardApp.Controllers
{
    [DisableCors]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RepairCaseController : ControllerBase
    {
        private readonly RepairCaseService _repairCaseService;

        public RepairCaseController(RepairCaseService repairCaseService)
        {
            _repairCaseService = repairCaseService;
            
        }

        [HttpGet]
        public async Task<IEnumerable<RepairCase>> GetAllRepairCases()
        {
            return await _repairCaseService.GetAllRepairCases();
        }

        [HttpPost]
        public async Task<ActionResult<RepairCase>> RegisterRepairCase([FromBody] RepairCaseDto dto)
        {
            return await _repairCaseService.RegisterRepairCase(dto);
        }

        [HttpPut]
        public async Task<ActionResult<RepairCase>> UpdateRepairCase([FromBody] RepairCase repairCase)
        {
            return await _repairCaseService.UpdateRepairCase(repairCase);
        }
    }
}