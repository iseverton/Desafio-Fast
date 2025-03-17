namespace WorkshopManager.Api.DTOs.WorkShopDTOs
{
    public class WorkshopReponseAllDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public int CreatedById { get; set; }
    }
}
