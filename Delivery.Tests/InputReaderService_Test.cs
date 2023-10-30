using Delivery.Application;
using Delivery.Application.Interfaces;
using Delivery.Application.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace Delivery.Tests
{
    [TestClass]
    public class InputReaderService_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationException), "File not encountered!")]
        public void ShoudNotReadInexistentFile()
        {
            IInputReaderService inputReaderService = new InputReaderService();
            inputReaderService.ReadFile(@"./TestFile.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException), "File is Empty!")]
        public void ShoudNotReadEmptyFile()
        {
            FileInfo fileInfo = new FileInfo(@"./TestFile.txt");
            fileInfo.Create();

            IInputReaderService inputReaderService = new InputReaderService();
            inputReaderService.ReadFile(fileInfo.FullName);

            fileInfo.Delete();
        }

        [TestMethod]
        public void ShouldMapObjects()
        {
            List<string> inputFileLines = new List<string>();
            inputFileLines.Add("[Drone 1], [100]");
            inputFileLines.Add("[Location 1], [100]");

            IInputReaderService inputReaderService = new InputReaderService();
            Tuple<List<Drone>, List<Location>> result = inputReaderService.MapObjects(inputFileLines.ToArray());

            Assert.IsTrue(
                            result.Item1[0].Name.Equals("[Drone 1]") &&
                            result.Item1[0].MaximumWeight == 100 &&
                            result.Item2[0].Name.Equals("[Location 1]") &&
                            result.Item2[0].PackageWeight == 100 &&
                            result.Item2[0].DroneAssigned == false);
        }

        [TestMethod]
        public void ShouldMapDrones()
        {
            List<string> inputFileLines = new List<string>();
            inputFileLines.Add("[Drone 1], [100]");

            IInputReaderService inputReaderService = new InputReaderService();
            List<Drone> drones = inputReaderService.MapDrones(inputFileLines.ToArray());

            Assert.IsTrue(drones[0].Name.Equals("[Drone 1]") &&
                          drones[0].MaximumWeight == 100);
        }

        [TestMethod]
        public void ShouldMapLocations()
        {
            List<string> inputFileLines = new List<string>();
            inputFileLines.Add(string.Empty);
            inputFileLines.Add("[Location 1], [100]");

            IInputReaderService inputReaderService = new InputReaderService();
            List<Location> locations = inputReaderService.MapLocations(inputFileLines.ToArray());

            Assert.IsTrue(locations[0].Name.Equals("[Location 1]") &&
                          locations[0].PackageWeight == 100 &&
                          locations[0].DroneAssigned == false);
        }
    }
}