using System.Text;

namespace Delivery.Application.Services
{
    public class PrintService
    {
        public void PrintFileContent(string[] inputFileLines)
        {
            foreach (string line in inputFileLines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine(Environment.NewLine);
        }

        public void PrintDroneTrips(List<Drone> drones, List<Trip> trips)
        {
            foreach (Drone drone in drones)
            {
                List<Trip> droneTrips = trips.Where(x => x.Drone == drone).ToList();

                Console.WriteLine(drone.Name);
                foreach (Trip trip in droneTrips)
                {
                    int tripNumber = droneTrips.IndexOf(trip) + 1;
                    Console.WriteLine("Trip #" + tripNumber);
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (Location location in trip.Locations)
                    {
                        stringBuilder.Append(location.Name + ", ");
                    }

                    string locationsString = stringBuilder.ToString();

                    int lastIndex = locationsString.LastIndexOf(", ");
                    locationsString = locationsString.Substring(0, lastIndex);
                    Console.WriteLine(locationsString);
                }

                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
