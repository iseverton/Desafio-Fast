using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using WorkshopManager.Api.DTOs.EmployeeDtos;
using WorkshopManager.Api.DTOs.EmployeeDtos.Validations;
using WorkshopManager.Api.DTOs.ResponseDTOs;
using WorkshopManager.Api.Models;
using WorkshopManager.Api.Repositories;
using WorkshopManager.Api.Repositories.Interfaces;
using WorkshopManager.Api.Services.Interfaces;

namespace WorkshopManager.Api.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository employeeRepository,IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDTO<bool>> DeleteEmployee(int id)
    {
       var employee = await _employeeRepository.GetByIdAsync(id);
       if (employee is null) return ResponseDTO<bool>.Fail("Employee not found", HttpStatusCode.NotFound);
        
       await _employeeRepository.RemoveAsync(employee);
       return ResponseDTO<bool>.Success(true, HttpStatusCode.OK);

    }

    public async Task<ResponseDTO<List<EmployeeResponseDTO>>> GetAll()
    {
        var result = await _employeeRepository.GetAllAsync();
        if (result is null) return ResponseDTO<List<EmployeeResponseDTO>>.Fail("Employee not found",HttpStatusCode.NotFound);
        var model = _mapper.Map<List<EmployeeResponseDTO>>(result);
        return ResponseDTO<List<EmployeeResponseDTO>>.Success(model, HttpStatusCode.OK);
    }

    public async Task<ResponseDTO<EmployeeResponseDTO>> GetById(int id)
    {
        var result = await _employeeRepository.GetByIdAsync(id);
        if (result is null) return ResponseDTO<EmployeeResponseDTO>.Fail("Employee not found", HttpStatusCode.NotFound);

        var model = _mapper.Map<EmployeeResponseDTO>(result);
        return ResponseDTO<EmployeeResponseDTO>.Success(model,HttpStatusCode.OK);
    }

    public async Task<ResponseDTO<int?>> PostEmployeeAsync(EmployeeCreateDTO employeeCreateDTO)
    {
        // verificar se o email ja existe
        var emailExists = await _employeeRepository.EmailExistsAsync(employeeCreateDTO.Email);
        if (emailExists) return ResponseDTO<int?>.Fail("Email already exists", HttpStatusCode.BadRequest);


        var result = new EmployeeCreateDTOValidation().Validate(employeeCreateDTO);
        if (!result.IsValid)
        {
            var errors = result.Errors
                .Select(e => new ErrorDetail
                {
                    Message = e.ErrorMessage,
                    Code = e.ErrorCode,
                    Target = e.PropertyName
                }).ToList();
            return ResponseDTO<int?>.Fail(errors, HttpStatusCode.BadRequest);

        }
       
        var model = _mapper.Map<Employee>(employeeCreateDTO);
        await _employeeRepository.AddAsync(model);
        return ResponseDTO<int?>.Success(model.Id, HttpStatusCode.Created);
    }

    public async Task<ResponseDTO<EmployeeUpdateDTO>> UpdateEmployee(int id, EmployeeUpdateDTO employeeUpdateDTO)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        if (employee is null) return ResponseDTO<EmployeeUpdateDTO>.Fail("Employee not found", HttpStatusCode.NotFound);

        var model = _mapper.Map(employeeUpdateDTO, employee);
        await _employeeRepository.UpdateAsync(model);
        return ResponseDTO<EmployeeUpdateDTO>.Success(employeeUpdateDTO, HttpStatusCode.OK);
    }
}
