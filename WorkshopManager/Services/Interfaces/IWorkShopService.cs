using WorkshopManager.Api.DTOs.ResponseDTOs;
using WorkshopManager.Api.DTOs.WorkShopDTOs;

namespace WorkshopManager.Api.Services.Interfaces;

public interface IWorkShopService
{
    Task<ResponseDTO<List<WorkshopReponseAllDTO>>> GetAll();
    Task<ResponseDTO<WorkShopResponseDTO>> GetById(int id);
    Task<ResponseDTO<WorkShopResponseDTO>> PostWorkShopAsync(int userId,WorkShopCreateDTO workShopCreateDTO);
    Task<ResponseDTO<WorkShopUpdateDTO>> UpdateWorkShop(int userId, int id, WorkShopUpdateDTO workShopUpdateDTO);
    Task<ResponseDTO<bool>> DeleteWorkShop(int userId, int id);
    Task<ResponseDTO<JoinWorkshopDTO>> JoinWorkshop(int userId, int id);
    Task<ResponseDTO<JoinWorkshopDTO>> LeaveWorkshop(int userId, int id);
}
