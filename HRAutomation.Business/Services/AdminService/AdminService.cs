using AutoMapper;
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
        public readonly IMapper _mapper;

        public AdminService(IEmployeeRepo employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public async Task AddManager(AddManagerDTO addManagerDTO)
        {
            var employee = _mapper.Map<Employee>(addManagerDTO);
            employee.Roles = Roles.Manager;
            employee.Password = GivePassword();

            await _employeeRepo.Add(employee);
        }

        public async Task<List<ListOfManagersVM>> ListOfManagers()
        {
            var managers = await _employeeRepo.GetFilteredList(
                select: x => new ListOfManagersVM
                {
                    Id =x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    EmailAddress = x.EmailAddress,
                    Salary = x.Salary,
                }, where: x => x.Status == Status.Active && x.Roles == Roles.Manager,
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

        public async Task<UpdateManagerDTO> GetManager(Guid id)
        {
            var employeeVM = await _employeeRepo.GetFilteredFirstOrDefault(select: x => new UpdateManagerVM
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                EmailAddress = x.EmailAddress,
                Salary = x.Salary,
                IdentityNumber = x.IdentityNumber,
                UpdatedDate = x.UpdatedDate,
            }, where: x => x.Id == id);

            var updateDTO = _mapper.Map<UpdateManagerDTO>(employeeVM);
            return updateDTO;
        }

        public async Task UpdateManager(UpdateManagerDTO updateManagerDTO)
        {
            var employee = await _employeeRepo.GetById(updateManagerDTO.Id);
            employee.Name = updateManagerDTO.Name;
            employee.Surname = updateManagerDTO.Surname;
            employee.EmailAddress = updateManagerDTO.EmailAddress;
            employee.Salary = updateManagerDTO.Salary;
            employee.IdentityNumber = updateManagerDTO.IdentityNumber;
            employee.UpdatedDate = updateManagerDTO.UpdatedDate;

            await _employeeRepo.Update(employee);
        }
    }
}
