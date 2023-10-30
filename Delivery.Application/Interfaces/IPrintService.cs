namespace Delivery.Application.Interfaces
{
    public interface IPrintService
    {
        void PrintDroneTrips(List<Drone> drones, List<Trip> trips);
    }
}
