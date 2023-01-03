using HRAutomation.DataAccess.Abstract;
using HRAutomation.DataAccess.EntityFramework.Context;
using HRAutomation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAutomation.DataAccess.EntityFramework.Concrete
{
    public class AdminRepo : BaseRepo<Admin>, IAdminRepo
    {
        public AdminRepo(HRAutomationDbContext hRAutomationDbContext) : base(hRAutomationDbContext)
        {

        }

        public async Task<Admin> GetByEmail(string email, string password)
        {
            var admin = await _table.Where(x=>x.EmailAddress == email && x.Password == password).FirstOrDefaultAsync();
            return admin;
        }
    }
}
