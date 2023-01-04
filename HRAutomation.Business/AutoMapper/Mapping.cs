using AutoMapper;
using HRAutomation.Business.Models.DTOs;
using HRAutomation.Business.Models.VMs;
using HRAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAutomation.Business.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Employee,AddManagerDTO>().ReverseMap();
            CreateMap<Employee,ListOfManagersVM>().ReverseMap();
            CreateMap<UpdateManagerDTO, UpdateManagerVM>().ReverseMap();
            CreateMap<Employee, UpdateManagerDTO>().ReverseMap();
            CreateMap<Employee, UpdateManagerVM>().ReverseMap();
        }
    }
}
