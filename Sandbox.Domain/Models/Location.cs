namespace Sandbox.Domain.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<HomeItem> HomeItems { get; set; }
    }
}
