using VehicleWorkshop.Interfaces;

namespace VehicleWorkshop.Components;

public sealed class StandardBrakes : IBrakes
{
    public string Brake() => "standard brakes engage";
}

public sealed class SportBrakes : IBrakes
{
    public string Brake() => "sport brakes engage";
}

public sealed class HeavyDutyBrakes : IBrakes
{
    public string Brake() => "heavy-duty brakes engage";
}
