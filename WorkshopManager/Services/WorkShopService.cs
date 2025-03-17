using AutoMapper;
using System.Net;
using WorkshopManager.Api.DTOs.ResponseDTOs;
using WorkshopManager.Api.DTOs.WorkShopDTOs;
using WorkshopManager.Api.Models;
using WorkshopManager.Api.Repositories;
using WorkshopManager.Api.Repositories.Interfaces;
using WorkshopManager.Api.Services.Interfaces;

namespace WorkshopManager.Api.Services
{
    public class WorkShopService : IWorkShopService
    {
        private readonly IWorkShopRepository _workShopRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public WorkShopService(IWorkShopRepository workShopRepository, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _workShopRepository = workShopRepository;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<ResponseDTO<bool>> DeleteWorkShop(int UserId, int id)
        {
            var workShop = await _workShopRepository.GetByIdAsync(id);
            if (workShop is null) return ResponseDTO<bool>.Fail("WorkShop not found", HttpStatusCode.NotFound);

            if (workShop.CreatedById != UserId) return ResponseDTO<bool>.Fail("You are not authorized to delete this workshop", HttpStatusCode.Unauthorized);

            await _workShopRepository.RemoveAsync(workShop);
            return ResponseDTO<bool>.Success(true, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<List<WorkshopReponseAllDTO>>> GetAll()
        {
            var result = await _workShopRepository.GetAllWithEmployeesAsync();
            if (result is null) return ResponseDTO<List<WorkshopReponseAllDTO>>.Fail("WorkShop not found", HttpStatusCode.NotFound);
            var model = _mapper.Map<List<WorkshopReponseAllDTO>>(result);
            return ResponseDTO<List<WorkshopReponseAllDTO>>.Success(model, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<WorkShopResponseDTO>> GetById(int id)
        {
            var result = await _workShopRepository.GetByIdWithEmployeeAsync(id);
            if (result is null) return ResponseDTO<WorkShopResponseDTO>.Fail("WorkShop not found", HttpStatusCode.NotFound);
            var model = _mapper.Map<WorkShopResponseDTO>(result);
            return ResponseDTO<WorkShopResponseDTO>.Success(model, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<JoinWorkshopDTO>> JoinWorkshop(int userId, int id)
        {
            var workshop = await _workShopRepository.GetByIdAsync(id);
            if (workshop is null) return ResponseDTO<JoinWorkshopDTO>.Fail("Workshop not found", HttpStatusCode.NotFound);
            var employee = await _employeeRepository.GetByIdAsync(userId);

            workshop.Employees.Add(employee);
            await _workShopRepository.UpdateAsync(workshop);
            var model = new JoinWorkshopDTO(userId,id);
            return ResponseDTO<JoinWorkshopDTO>.Success(model, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<JoinWorkshopDTO>> LeaveWorkshop(int userId, int id)
        {
            var workshop = await _workShopRepository.GetByIdWithEmployeeAsync(id);
            if (workshop is null) return ResponseDTO<JoinWorkshopDTO>.Fail("Workshop not found", HttpStatusCode.NotFound);

            var employee = await _employeeRepository.GetByIdAsync(userId);
            if (employee is null) return ResponseDTO<JoinWorkshopDTO>.Fail("Employee not found", HttpStatusCode.NotFound);
            
            var employeeExists = workshop.Employees.FirstOrDefault(e => e.Id == userId);
            workshop.Employees.Remove(employeeExists);
            await _workShopRepository.UpdateAsync(workshop);
            var model = new JoinWorkshopDTO(userId, id);
            return ResponseDTO<JoinWorkshopDTO>.Success(model, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<WorkShopResponseDTO>> PostWorkShopAsync(int userId,WorkShopCreateDTO workShopCreateDTO)
        {
            var model = _mapper.Map<Workshop>(workShopCreateDTO);
            model.CreatedById = userId;
            await _workShopRepository.AddAsync(model);
            var modelDto = _mapper.Map<WorkShopResponseDTO>(model);
            return ResponseDTO<WorkShopResponseDTO>.Success(modelDto, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<WorkShopUpdateDTO>> UpdateWorkShop(int UserId, int id, WorkShopUpdateDTO workShopUpdateDTO)
        {
            var workShop = await _workShopRepository.GetByIdAsync(id);
            if (workShop is null) return ResponseDTO<WorkShopUpdateDTO>.Fail("WorkShop not found", HttpStatusCode.NotFound);

            if (workShop.CreatedById != UserId) return ResponseDTO<WorkShopUpdateDTO>.Fail("You are not authorized to update this workshop", HttpStatusCode.Unauthorized);

            var model = _mapper.Map(workShopUpdateDTO, workShop);
            await _workShopRepository.UpdateAsync(model);
            return ResponseDTO<WorkShopUpdateDTO>.Success(workShopUpdateDTO, HttpStatusCode.OK);

        }
    }
}
