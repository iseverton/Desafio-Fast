using WorkshopManager.Api.DTOs.AuthDTOs;
using WorkshopManager.Api.DTOs.ResponseDTOs;

namespace WorkshopManager.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDTO<string>> Login(LoginDTO loginDTO);
    }
}
