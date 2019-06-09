using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BoardApp.Models.dto;
using BoardApp.Models.enums;
using Microsoft.AspNetCore.Http;

namespace BoardApp.Models
{
    public class RepairCase
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CaseStatus Status { get; set; }
        public Worker Worker { get; set; }
        public string RegistrationTime { get; set; }
        public string LastUpdate { get; set; }
        public Equipment Equipment { get; set; }

        public static RepairCase Create(RepairCaseDto dto)
        {
            return new RepairCase
            {
                Title = dto.Title,
                Description = dto.Description,
                RegistrationTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                LastUpdate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                Status = CaseStatus.NEW
            };
        }
        
    }
}