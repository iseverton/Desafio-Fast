﻿using WorkshopManager.Api.DTOs.EmployeeDtos;
using WorkshopManager.Api.DTOs.ResponseDTOs;


namespace WorkshopManager.Api.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<ResponseDTO<List<EmployeeResponseDTO>>> GetAll();
        Task<ResponseDTO<EmployeeWorkshopResponseDTO>> GetById(int id);
        Task<ResponseDTO<EmployeeResponseDTO>> PostEmployeeAsync(EmployeeCreateDTO employeeCreateDTO);
        Task<ResponseDTO<EmployeeUpdateDTO>> UpdateEmployee(int id, EmployeeUpdateDTO employeeUpdateDTO);
        Task<ResponseDTO<bool>> DeleteEmployee(int id);


    }
}
