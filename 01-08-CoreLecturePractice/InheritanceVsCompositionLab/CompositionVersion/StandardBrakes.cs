using InheritanceVsCompositionLab.Interfaces;

namespace InheritanceVsCompositionLab.CompositionVersion;

public sealed class StandardBrakes : IBrakes
{
    public string Brake()
    {
        return "Standard brakes slow the vehicle.";
    }
}
