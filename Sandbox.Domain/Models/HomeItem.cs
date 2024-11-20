namespace Sandbox.Domain.Models
{
    public class HomeItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
