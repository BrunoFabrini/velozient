using Delivery.Application;
using Delivery.Application.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delivery.Tests
{
    [TestClass]
    public class DeliveryService_Test
    {
        [TestMethod]
        public void ShouldPlanMinimunAmountOfTrips()
        {
            List<Drone> drones = new List<Drone>();

            Drone drone1 = new Drone();
            drone1.Name = "Drone 1";
            drone1.MaximumWeight = 5;
            drones.Add(drone1);

            Drone drone2 = new Drone();
            drone2.Name = "Drone 2";
            drone2.MaximumWeight = 15;
            drones.Add(drone2);


            List<Location> locations = new List<Location>();

            Location location1 = new Location();
            location1.Name = "Location 1";
            location1.PackageWeight = 10;
            locations.Add(location1);

            Location location2 = new Location();
            location2.Name = "Location 1";
            location2.PackageWeight = 5;
            locations.Add(location2);

            DeliveryService deliveryService = new DeliveryService();
            List<Trip> trips = deliveryService.PlanTrips(drones, locations);

            Assert.IsTrue(trips.Count == 1);
        }

        [TestMethod]
        public void ShouldNotAssignDrones()
        {
            List<Drone> drones = new List<Drone>();

            Drone drone1 = new Drone();
            drone1.Name = "Drone 1";
            drone1.MaximumWeight = 5;
            drones.Add(drone1);


            List<Location> locations = new List<Location>();

            Location location1 = new Location();
            location1.Name = "Location 1";
            location1.PackageWeight = 10;
            locations.Add(location1);


            DeliveryService deliveryService = new DeliveryService();
            List<Trip> trips = deliveryService.PlanTrips(drones, locations);

            Assert.IsTrue(trips.Count(x => x.Drone != null) == 0);
        }

        [TestMethod]
        public void ShouldHaveCorrectTripCurrentWeight()
        {
            Location location = new Location();
            location.PackageWeight = 10;

            Trip trip = new Trip();
            trip.Locations.Add(location);

            DeliveryService deliveryService = new DeliveryService();

            Assert.AreEqual(10, deliveryService.GetTripCurrentWeight(trip));
        }

        [TestMethod]
        public void ShouldNotHaveWeight()
        {
            Trip trip = new Trip();

            DeliveryService deliveryService = new DeliveryService();

            Assert.AreEqual(0, deliveryService.GetTripCurrentWeight(trip));
        }
    }
}