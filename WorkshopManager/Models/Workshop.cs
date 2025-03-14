namespace WorkshopManager.Api.Entities
{
    public class Workshop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public int CreatedById { get; set; }
        public Employee CreatedBy { get; set; }
        public ICollection<Employee> Employees { get; set; }
        
    }
}
