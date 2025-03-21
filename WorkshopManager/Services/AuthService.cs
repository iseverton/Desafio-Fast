﻿using Microsoft.AspNetCore.Authentication;
using System.Net;
using WorkshopManager.Api.DTOs.AuthDTOs;
using WorkshopManager.Api.DTOs.EmployeeDtos;
using WorkshopManager.Api.DTOs.ResponseDTOs;
using WorkshopManager.Api.Repositories.Interfaces;
using WorkshopManager.Api.Services.Interfaces;

namespace WorkshopManager.Api.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly IEmployeeRepository _employeeRepository;

    public AuthService(ITokenService tokenService, IEmployeeRepository employeeRepository)
    {
        _tokenService = tokenService;
        _employeeRepository = employeeRepository;
    }

    public async Task<ResponseDTO<string>> Login(LoginDTO loginDTO)
    {
        var result = new LoginDTOValidation().Validate(loginDTO);
        if (!result.IsValid) 
        {
            var errors = result.Errors
               .Select(e => new ErrorDetail
               {
                   Message = e.ErrorMessage,
                   Code = e.ErrorCode,
                   Target = e.PropertyName
               }).ToList();
            return ResponseDTO<string>.Fail(errors, HttpStatusCode.BadRequest);
        }
        var employeeExist = await _employeeRepository.ValidateCredentialsAsync(loginDTO.Email, loginDTO.Password);
        if (employeeExist is null) return ResponseDTO<string>.Fail("Invalid credentials", HttpStatusCode.BadRequest);
        var token =  _tokenService.GenerateToken(employeeExist);
        return ResponseDTO<string>.Success(token, HttpStatusCode.OK);
    }
}
