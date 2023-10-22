namespace Delivery.Application.Services
{
    public class DeliveryService
    {
        public List<Trip> PlanTrips(List<Drone> drones, List<Location> locations)
        {
            List<Trip> trips = new List<Trip>();
            Trip trip = new Trip();

            foreach (Location location in locations)
            {
                int tripWeight = GetTripCurrentWeight(trip);

                foreach (Drone drone in drones)
                {
                    if (tripWeight + location.PackageWeight <= drone.MaximumWeight)
                    {
                        location.DroneAssigned = true;
                        trip.Locations.Add(location);
                        trip.Drone = drone;
                        break;
                    }
                }

                bool createNewTrip = !location.DroneAssigned;
                if (createNewTrip)
                {
                    trips.Add(trip);

                    trip = new Trip();
                    trip.Locations.Add(location);
                }
            }

            if (trip.Locations.Any())
            {
                trips.Add(trip);
            }

            return trips;
        }

        public int GetTripCurrentWeight(Trip trip)
        {
            return trip.Locations.Sum(x => x.PackageWeight);
        }
    }
}
