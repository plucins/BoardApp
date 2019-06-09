using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoardApp.Models;
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
    public class WorkerController
    {
        private readonly WorkerService _workerService;

        
        public WorkerController(WorkerService workerService)
        {
            _workerService = workerService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Worker>> GetAllWorkers()
        {
            return await _workerService.GetAllWorkers();
        }
        [HttpGet("{id}")]
        public async Task<Worker> GetWorkerById(long id)
        {
            return await _workerService.GetWorkerById(id);
        }
    }
}