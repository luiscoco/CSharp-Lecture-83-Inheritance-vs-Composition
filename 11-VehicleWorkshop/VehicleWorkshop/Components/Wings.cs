using VehicleWorkshop.Interfaces;

namespace VehicleWorkshop.Components;

public sealed class FixedWing : IWing
{
    public string Fly() => "fixed wing provides lift";
}

public sealed class FoldingWing : IWing
{
    public string Fly() => "folding wing deploys and provides lift";
}
