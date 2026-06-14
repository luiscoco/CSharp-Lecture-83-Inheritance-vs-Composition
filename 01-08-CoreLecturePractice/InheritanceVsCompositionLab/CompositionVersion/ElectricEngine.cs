using InheritanceVsCompositionLab.Interfaces;

namespace InheritanceVsCompositionLab.CompositionVersion;

public sealed class ElectricEngine : IEngine
{
    public string Start()
    {
        return "Electric engine starts silently.";
    }
}
