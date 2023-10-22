# Drone Delivery Service
The application consists in three steps:
1. Reading input data with drones and locations
2. Planning trips based on drones maximum weight capacity, package destinations and package weights
3. Outputing the calculated trips for each drone, highliting the locations of each trip

# Algorithm
The delivery algorithm firstly creates a trip and then checks every location package weight, compares the current trip weight to every drone capacity.
Then if it can fit the package weight within this same trip, the location is added to it. If it cannot fit, another trip is created with this location and it proceeds to the checking the next locations.

# Libraries 
- Microsoft.NET.Test.Sdk 17.3.2
> Library for writing unit test cases

# Technical Dependencies
- .NET 7.0
- Microsoft Visual Studio 2022
- A demo input file is present on the project and can by loaded by default
