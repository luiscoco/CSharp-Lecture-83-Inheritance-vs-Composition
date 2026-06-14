using InheritanceVsCompositionLab.Interfaces;

namespace InheritanceVsCompositionLab.CompositionVersion;

public sealed class CombustionEngine : IEngine
{
    public string Start()
    {
        return "Combustion engine starts with fuel.";
    }
}
