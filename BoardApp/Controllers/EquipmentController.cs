using System.Threading.Tasks;
using BoardApp.Models;
using BoardApp.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BoardApp.Controllers
{
    [DisableCors]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly EquipmentService _equipmentService;

        public EquipmentController(EquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpPost]
        public async Task<ActionResult<Equipment>> AddEquipment([FromBody] Equipment equipment)
        {
            return await _equipmentService.addEquipment(equipment);
        }
    }
}