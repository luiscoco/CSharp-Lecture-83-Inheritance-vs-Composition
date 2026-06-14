using InheritanceVsCompositionLab.Interfaces;

namespace InheritanceVsCompositionLab.Tests.Fakes;

public sealed class FakeBrakes : IBrakes
{
    public string Brake()
    {
        return "fake brakes";
    }
}
