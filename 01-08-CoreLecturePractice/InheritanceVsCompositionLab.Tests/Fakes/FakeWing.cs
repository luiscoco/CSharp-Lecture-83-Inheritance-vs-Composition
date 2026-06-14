using InheritanceVsCompositionLab.Interfaces;

namespace InheritanceVsCompositionLab.Tests.Fakes;

public sealed class FakeWing : IWing
{
    public string Fly()
    {
        return "fake wing";
    }
}
