using InheritanceVsCompositionLab.Interfaces;

namespace InheritanceVsCompositionLab.CompositionVersion;

public sealed class FixedWing : IWing
{
    public string Fly()
    {
        return "Fixed wing generates lift.";
    }
}
