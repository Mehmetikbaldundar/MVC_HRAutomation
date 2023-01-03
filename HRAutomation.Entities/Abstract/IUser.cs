using HRAutomation.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAutomation.Entities.Abstract
{
    public interface IUser
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string EmailAddress { get; set; }
        string Password { get; set; }
        Status Status { get; set; }
        Roles Roles { get; set; }
    }
}
