using WorkshopManager.Api.DTOs.Employee;
using WorkshopManager.Api.DTOs.ResponseDTOs;
using WorkshopManager.Api.Entities;

namespace WorkshopManager.Api.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<ResponseDTO<List<EmployeeResponseDTO>>> GetAll();
        Task<ResponseDTO<EmployeeResponseDTO>> GetById(int id);
        Task<ResponseDTO<int?>> PostEmployeeAsync(EmployeeCreateDTO employeeCreateDTO);
        Task<ResponseDTO<EmployeeUpdateDTO>> UpdateEmployee(int id, EmployeeUpdateDTO employeeUpdateDTO);
        Task<ResponseDTO<bool>> DeleteEmployee(int id);
        
    }
}
