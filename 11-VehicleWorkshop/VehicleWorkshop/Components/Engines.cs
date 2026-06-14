using VehicleWorkshop.Interfaces;

namespace VehicleWorkshop.Components;

public sealed class CombustionEngine : IEngine
{
    public string Start() => "combustion engine starts";
}

public sealed class ElectricEngine : IEngine
{
    public string Start() => "electric engine starts";
}

public sealed class HybridEngine : IEngine
{
    public string Start() => "hybrid engine starts";
}
