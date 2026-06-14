using CompositionVehicle = InheritanceVsCompositionLab.CompositionVersion.Vehicle;
using InheritanceVsCompositionLab.CompositionVersion;
using InheritanceVsCompositionLab.InheritanceVersion;

namespace InheritanceVsCompositionLab.Demo;

public static class DemoRunner
{
    public static void Run()
    {
        RunInheritanceDemo();
        Console.WriteLine();
        RunCompositionDemo();
        Console.WriteLine();
        ExplainFiles();
    }

    private static void RunInheritanceDemo()
    {
        Console.WriteLine("Inheritance version");

        var car = new Car("Blue", 1400, 210);
        var truck = new Truck("White", 5500, 140);
        var lambo = new Lambo("Yellow", 1550, 330);

        Console.WriteLine(car.Describe());
        Console.WriteLine(car.Move());
        Console.WriteLine(car.OpenTrunk());
        Console.WriteLine(truck.LoadCargo());
        Console.WriteLine(lambo.EnableTrackMode());

        Console.WriteLine("Is-a relationship: Car, Truck, and Lambo are all Vehicles.");
        Console.WriteLine("Trap: every new capability can create more subclasses and duplicated combinations.");
    }

    private static void RunCompositionDemo()
    {
        Console.WriteLine("Composition version");

        var dailyCar = new CompositionVehicle(
            "Daily car",
            new CombustionEngine(),
            new StandardBrakes(),
            new StandardSeats());

        var electricSportsCar = new CompositionVehicle(
            "Electric sports car",
            new ElectricEngine(),
            new SportBrakes(),
            new RacingSeats());

        var flyingPrototype = new CompositionVehicle(
            "Flying prototype",
            new CombustionEngine(),
            new SportBrakes(),
            new RacingSeats(),
            new FixedWing());

        foreach (var vehicle in new[] { dailyCar, electricSportsCar, flyingPrototype })
        {
            Console.WriteLine(vehicle.Start());
            Console.WriteLine(vehicle.Brake());
            Console.WriteLine(vehicle.Sit());
            Console.WriteLine(vehicle.Fly());
        }

        Console.WriteLine("Runtime engine swap");
        Console.WriteLine(dailyCar.Start());
        dailyCar.ReplaceEngine(new ElectricEngine());
        Console.WriteLine(dailyCar.Start());

        Console.WriteLine("Has-a relationship: a Vehicle has an engine, brakes, seats, and optionally a wing.");
    }

    private static void ExplainFiles()
    {
        Console.WriteLine("File guide");
        Console.WriteLine("InheritanceVersion: base Vehicle plus Car, Truck, and Lambo.");
        Console.WriteLine("Interfaces: small contracts for replaceable components.");
        Console.WriteLine("CompositionVersion: component implementations and a Vehicle assembled from them.");
        Console.WriteLine("Demo: console examples for reuse, dynamic assembly, and runtime swapping.");
        Console.WriteLine("Docs: the ADR explaining the architecture decision.");
    }
}
