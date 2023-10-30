namespace Delivery.Application.Interfaces
{
    public interface IDeliveryService
    {
        List<Trip> PlanTrips(List<Drone> drones, List<Location> locations);

        int GetTripCurrentWeight(Trip trip);
    }
}
