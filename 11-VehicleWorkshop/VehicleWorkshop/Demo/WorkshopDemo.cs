namespace VehicleWorkshop.Demo;

public static class WorkshopDemo
{
    public static void Run()
    {
        foreach (var vehicle in VehicleFactory.CreateExamples())
        {
            Console.WriteLine(vehicle.Start());
            Console.WriteLine(vehicle.Stop());
            Console.WriteLine(vehicle.Enter());
            Console.WriteLine(vehicle.Fly());
            Console.WriteLine();
        }
    }
}
