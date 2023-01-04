using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAutomation.Business.Models.DTOs
{
    public class UpdateManagerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public decimal? Salary { get; set; }
        public string? IdentityNumber { get; set; }
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
    }
}
