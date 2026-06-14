using VehicleWorkshop.Components;
using VehicleWorkshop.Models;

namespace VehicleWorkshop.Demo;

public static class VehicleFactory
{
    public static IReadOnlyList<Vehicle> CreateExamples()
    {
        return
        [
            new Vehicle("City commuter", new ElectricEngine(), new StandardBrakes(), new StandardSeats()),
            new Vehicle("Track car", new CombustionEngine(), new SportBrakes(), new RacingSeats()),
            new Vehicle("Work truck", new CombustionEngine(), new HeavyDutyBrakes(), new UtilitySeats()),
            new Vehicle("Hybrid tourer", new HybridEngine(), new StandardBrakes(), new StandardSeats()),
            new Vehicle("Flying prototype", new HybridEngine(), new SportBrakes(), new RacingSeats(), new FoldingWing())
        ];
    }
}
