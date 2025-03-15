using AutoMapper;
using WorkshopManager.Api.DTOs.Employee;
using WorkshopManager.Api.Entities;

namespace WorkshopManager.Api.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeCreateDTO>().ReverseMap();
        CreateMap<Employee, EmployeeResponseDTO>().ReverseMap();
        CreateMap<EmployeeUpdateDTO, Employee>();
    }
}
