using HRAutomation.Business.Models.DTOs;
using HRAutomation.Business.Models.VMs;
using HRAutomation.Core.Enums;
using HRAutomation.DataAccess.Abstract;
using HRAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAutomation.Business.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IEmployeeRepo _employeeRepo;

        public AdminService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task AddManager(AddManagerDTO addManagerDTO)
        {
            Employee employee = new Employee();
            employee.Id = addManagerDTO.Id;
            employee.Name = addManagerDTO.Name;
            employee.Salary = addManagerDTO.Salary;
            employee.Surname = addManagerDTO.Surname;
            employee.CreatedDate = addManagerDTO.CreatedDate;
            employee.Status = addManagerDTO.Status;
            employee.EmailAddress = addManagerDTO.EmailAddress;
            employee.Password = GivePassword();

            await _employeeRepo.Add(employee);
        }

        public async Task<List<ListOfManagersVM>> ListOfManagers()
        {
            var managers = await _employeeRepo.GetFilteredList(
                select: x => new ListOfManagersVM
                {
                    Name = x.Name,
                    Surname = x.Surname,
                    EmailAddress = x.EmailAddress,
                    Salary = x.Salary,
                }, where: x => x.Status == Status.Active,
                orderBy: x => x.OrderBy(x => x.Name));

            return managers;
        }

        private string GivePassword()
        {
            Random rnd = new Random();
            string password = String.Empty;

            for (int i = 1; i <= 6; i++)
            {
                int value = rnd.Next(65, 91);
                password += (char)value;
            }
            return password;
        }
    }
}
