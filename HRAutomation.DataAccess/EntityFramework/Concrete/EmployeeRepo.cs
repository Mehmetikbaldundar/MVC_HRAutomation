using HRAutomation.DataAccess.Abstract;
using HRAutomation.DataAccess.EntityFramework.Context;
using HRAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAutomation.DataAccess.EntityFramework.Concrete
{
    public class EmployeeRepo : BaseRepo<Employee>, IEmployeeRepo
    {
        public EmployeeRepo(HRAutomationDbContext hRAutomationDbContext) : base(hRAutomationDbContext)
        {

        }
    }
}
