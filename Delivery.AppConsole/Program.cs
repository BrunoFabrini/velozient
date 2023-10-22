using Delivery.Application;
using Delivery.Application.Services;

string inputFilePath = @".\Input\Input.txt";

Console.WriteLine("VELOZIENT - DRONE DELIVERY SERVICE");
Console.WriteLine("Type the full path of your input file or just press enter to run a demo:");
string userInput = Console.ReadLine();

if (string.IsNullOrEmpty(userInput))
{
    Console.WriteLine("Running program with demo file...");
}
else
{
    inputFilePath = userInput;
}

InputReaderService inputReaderService = new InputReaderService();
string[] inputFileLines = inputReaderService.ReadFile(inputFilePath);
Tuple<List<Drone>, List<Location>> result = inputReaderService.MapObjects(inputFileLines);

List<Drone> drones = result.Item1;
List<Location> locations = result.Item2;

DeliveryService deliveryService = new DeliveryService();
List<Trip> trips = deliveryService.PlanTrips(drones, locations);

PrintService printService = new PrintService();

Console.WriteLine("INPUT:");
printService.PrintFileContent(inputFileLines);

Console.WriteLine("OUTPUT:");
printService.PrintDroneTrips(drones, trips);

Console.WriteLine("Press any key to close...");
Console.ReadKey();