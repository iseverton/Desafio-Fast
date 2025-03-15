using AutoMapper;
using System.Net;
using WorkshopManager.Api.DTOs.ResponseDTOs;
using WorkshopManager.Api.DTOs.WorkShopDTOs;
using WorkshopManager.Api.Models;
using WorkshopManager.Api.Repositories.Interfaces;
using WorkshopManager.Api.Services.Interfaces;

namespace WorkshopManager.Api.Services
{
    public class WorkShopService : IWorkShopService
    {
        private readonly IWorkShopRepository _workShopRepository;
        private readonly IMapper _mapper;
public WorkShopService(IWorkShopRepository workShopRepository, IMapper mapper)
        {
            _workShopRepository = workShopRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<bool>> DeleteWorkShop(int id)
        {
            var workShop = await _workShopRepository.GetByIdAsync(id);
            if (workShop is null) return ResponseDTO<bool>.Fail("WorkShop not found", HttpStatusCode.NotFound);
            await _workShopRepository.RemoveAsync(workShop);
            return ResponseDTO<bool>.Success(true, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<List<WorkShopResponseDTO>>> GetAll()
        {
            var result = await _workShopRepository.GetAllAsync();
            if (result is null) return ResponseDTO<List<WorkShopResponseDTO>>.Fail("WorkShop not found", HttpStatusCode.NotFound);
            var model = _mapper.Map<List<WorkShopResponseDTO>>(result);
            return ResponseDTO<List<WorkShopResponseDTO>>.Success(model, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<WorkShopResponseDTO>> GetById(int id)
        {
            var result = await _workShopRepository.GetByIdAsync(id);
            if (result is null) return ResponseDTO<WorkShopResponseDTO>.Fail("WorkShop not found", HttpStatusCode.NotFound);
            var model = _mapper.Map<WorkShopResponseDTO>(result);
            return ResponseDTO<WorkShopResponseDTO>.Success(model, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<int?>> PostWorkShopAsync(WorkShopCreateDTO workShopCreateDTO)
        {
            var model = _mapper.Map<Workshop>(workShopCreateDTO);
            var result = await _workShopRepository.AddAsync(model);
            return ResponseDTO<int?>.Success(model.Id, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<WorkShopUpdateDTO>> UpdateWorkShop(int id, WorkShopUpdateDTO workShopUpdateDTO)
        {
            var workShop = await _workShopRepository.GetByIdAsync(id);
            if (workShop is null) return ResponseDTO<WorkShopUpdateDTO>.Fail("WorkShop not found", HttpStatusCode.NotFound);
            var model = _mapper.Map(workShopUpdateDTO, workShop);
            await _workShopRepository.UpdateAsync(model);
            return ResponseDTO<WorkShopUpdateDTO>.Success(workShopUpdateDTO, HttpStatusCode.OK);

        }
    }
}
