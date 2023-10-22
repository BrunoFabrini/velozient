namespace Delivery.Application
{
    public class Trip
    {
        public Drone Drone { get; set; }

        public List<Location> Locations { get; set; } = new List<Location>();
    }
}
