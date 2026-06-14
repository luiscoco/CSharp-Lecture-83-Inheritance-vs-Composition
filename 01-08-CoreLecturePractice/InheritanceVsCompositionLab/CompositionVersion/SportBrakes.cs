using InheritanceVsCompositionLab.Interfaces;

namespace InheritanceVsCompositionLab.CompositionVersion;

public sealed class SportBrakes : IBrakes
{
    public string Brake()
    {
        return "Sport brakes stop the vehicle quickly.";
    }
}
