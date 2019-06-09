using System.Collections.Generic;
using System.Threading.Tasks;
using BoardApp.Models;
using BoardApp.Repository;

namespace BoardApp.Services
{
    public class WorkerService
    {

        private readonly WorkerRepository _workerRepository;

        public WorkerService(WorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public async Task<IEnumerable<Worker>> GetAllWorkers()
        {
            return await _workerRepository.GetAll();
        }


        public async Task<Worker> GetWorkerById(long id)
        {
            return await _workerRepository.GetById(id);
        }
    }
}