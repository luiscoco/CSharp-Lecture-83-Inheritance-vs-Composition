using VehicleWorkshop.Interfaces;

namespace VehicleWorkshop.Components;

public sealed class StandardSeats : ISeats
{
    public string Sit() => "standard seats support passengers";
}

public sealed class RacingSeats : ISeats
{
    public string Sit() => "racing seats support fast cornering";
}

public sealed class UtilitySeats : ISeats
{
    public string Sit() => "utility seats support long work days";
}
