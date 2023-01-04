using HRAutomation.Business.Models.DTOs;
using HRAutomation.Business.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAutomation.Business.Services.AdminService
{
    public interface IAdminService
    {
        Task AddManager(AddManagerDTO addManagerDTO);

        Task<List<ListOfManagersVM>> ListOfManagers();

        Task<UpdateManagerDTO> GetManager(Guid id);
        Task UpdateManager(UpdateManagerDTO updateManagerDTO);
    }
}
