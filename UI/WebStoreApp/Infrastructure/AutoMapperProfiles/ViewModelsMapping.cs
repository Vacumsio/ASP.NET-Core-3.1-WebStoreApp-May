using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.Domain.Entities;
using WebStoreApp.Domain.Entities.Employees;
using WebStoreApp.Domain.ViewModels;

namespace WebStoreApp.Infrastructure.AutoMapperProfiles
{
    public class ViewModelsMapping: Profile
    {
        public ViewModelsMapping()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(view_model => view_model.Brand, opt => opt.MapFrom(product => product.Brand.Name))
                .ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
                
        }
    }
}
