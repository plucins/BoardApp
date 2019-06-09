using System.Collections.Generic;
using System.Threading.Tasks;
using BoardApp.Models;
using BoardApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BoardApp.Services
{
    public class EquipmentService
    {
        private readonly EquipmentRepository _equipmentRepository;
        private readonly OwnerRepository _ownerRepository;

        public EquipmentService(EquipmentRepository equipmentRepository, OwnerRepository ownerRepository)
        {
            _equipmentRepository = equipmentRepository;
            _ownerRepository = ownerRepository;
        }


        public async Task<Equipment> addEquipment(Equipment equipment)
        {
            if (equipment.Owner != null)
            {
                if (_ownerRepository.FindOwnerPresentByAllData(equipment.Owner).Result != null)
                {
                    equipment.Owner = _ownerRepository.FindOwnerPresentByAllData(equipment.Owner).Result;
                }
                else
                {
                    equipment.Owner = _ownerRepository.Add(equipment.Owner).Result;
                }
            }
            
            return await _equipmentRepository.Add(equipment);
        }

        public async Task<IEnumerable<Equipment>> GetAll()
        {
            return await _equipmentRepository.GetAll();
        }
    }
}