namespace Delivery.Application.Interfaces
{
    public interface IInputReaderService
    {
        string[] ReadFile(string inputFilePath);

        Tuple<List<Drone>, List<Location>> MapObjects(string[] inputFileLines);

        List<Drone> MapDrones(string[] inputFileLines);

        List<Location> MapLocations(string[] inputFileLines);
    }
}
