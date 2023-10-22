using System.ComponentModel.DataAnnotations;

namespace Delivery.Application.Services
{
    public class InputReaderService
    {
        public string[] ReadFile(string inputFilePath)
        {
            FileInfo fileInfo = new FileInfo(inputFilePath);
            if (!fileInfo.Exists)
            {
                throw new ValidationException("File not encountered!");
            }

            if (fileInfo.Length == 0)
            {
                throw new ValidationException("File is Empty!");
            }

            string[] inputFileLines = File.ReadAllLines(inputFilePath);

            return inputFileLines;
        }

        public Tuple<List<Drone>, List<Location>> MapObjects(string[] inputFileLines)
        {
            List<Drone> drones = MapDrones(inputFileLines);
            List<Location> locations = MapLocations(inputFileLines);

            Tuple<List<Drone>, List<Location>> result = new Tuple<List<Drone>, List<Location>>(drones, locations);
            return result;
        }

        public List<Drone> MapDrones(string[] inputFileLines)
        {
            string[] droneInfo = inputFileLines[0].Replace(", ", ",").Split(',');
            List<Drone> drones = new List<Drone>();

            for (int i = 0; i < droneInfo.Length; i = i + 2)
            {
                Drone drone = new Drone();
                drone.Name = droneInfo[i];
                drone.MaximumWeight = Convert.ToInt32(droneInfo[i + 1].Replace("[", "").Replace("]", ""));

                drones.Add(drone);
            }

            return drones;
        }

        public List<Location> MapLocations(string[] inputFileLines)
        {
            List<Location> locations = new List<Location>();

            for (int i = 1; i < inputFileLines.Length; i++)
            {
                string[] locationInfo = inputFileLines[i].Replace(", ", ",").Split(',');

                Location location = new Location();
                location.Name = locationInfo[0];
                location.PackageWeight = Convert.ToInt32(locationInfo[1].Replace("[", "").Replace("]", ""));
                location.DroneAssigned = false;

                locations.Add(location);
            }

            return locations;
        }
    }
}
