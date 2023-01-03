using HRAutomation.Core.DataAccess.Abstract;
using HRAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAutomation.DataAccess.Abstract
{
    public interface IAdminRepo : IBaseRepo<Admin>
    {
        Task<Admin> GetByEmail(string email,string password);
    }
}
