﻿using WorkshopManager.Api.DTOs.ResponseDTOs;
using WorkshopManager.Api.DTOs.WorkShopDTOs;

namespace WorkshopManager.Api.Services.Interfaces;

public interface IWorkShopService
{
    Task<ResponseDTO<List<WorkShopResponseDTO>>> GetAll();
    Task<ResponseDTO<WorkShopResponseDTO>> GetById(int id);
    Task<ResponseDTO<int?>> PostWorkShopAsync(WorkShopCreateDTO workShopCreateDTO);
    Task<ResponseDTO<WorkShopUpdateDTO>> UpdateWorkShop(int UserId, int id, WorkShopUpdateDTO workShopUpdateDTO);
    Task<ResponseDTO<bool>> DeleteWorkShop(int UserId, int id);
    Task<ResponseDTO<JoinWorkshopDTO>> JoinWorkshop(int userId, int id);
}
