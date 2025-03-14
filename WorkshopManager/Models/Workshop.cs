namespace WorkshopManager.Api.Entities
{
    public class Workshop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime EventDate { get; set; }
        
    }
}
