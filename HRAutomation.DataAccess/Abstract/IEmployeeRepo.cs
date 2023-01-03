using HRAutomation.Core.DataAccess.Abstract;
using HRAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAutomation.DataAccess.Abstract
{
    public interface IEmployeeRepo : IBaseRepo<Employee>
    {
    }
}
