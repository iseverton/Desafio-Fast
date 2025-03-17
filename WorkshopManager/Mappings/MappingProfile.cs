using AutoMapper;
using WorkshopManager.Api.DTOs.EmployeeDtos;
using WorkshopManager.Api.Models;
using WorkshopManager.Api.DTOs.WorkShopDTOs;

namespace WorkshopManager.Api.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeCreateDTO>().ReverseMap();
        CreateMap<Employee, EmployeeResponseDTO>().ReverseMap();
        CreateMap<Employee, EmployeeWorkshopResponseDTO>().ReverseMap();
        CreateMap<EmployeeUpdateDTO, Employee>();

        CreateMap<Workshop, WorkShopCreateDTO>().ReverseMap();
        CreateMap<Workshop, WorkShopResponseDTO>().ReverseMap();
        CreateMap<Workshop, WorkshopEmployeeResponseDTO>().ReverseMap();
        CreateMap<Workshop, WorkshopReponseAllDTO>().ReverseMap();
        CreateMap<WorkShopUpdateDTO, Workshop>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));;

       
    }
}
