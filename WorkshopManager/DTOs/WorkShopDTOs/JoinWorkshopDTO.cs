namespace WorkshopManager.Api.DTOs.WorkShopDTOs;

public class JoinWorkshopDTO
{
    public int UserId { get; set; }
    public int WorkshopId { get; set; }

    public JoinWorkshopDTO(int userId, int workshopId)
    {
        UserId = userId;
        WorkshopId = workshopId;
    }
}
