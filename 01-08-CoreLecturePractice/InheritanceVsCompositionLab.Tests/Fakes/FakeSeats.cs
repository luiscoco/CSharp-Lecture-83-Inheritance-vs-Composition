using InheritanceVsCompositionLab.Interfaces;

namespace InheritanceVsCompositionLab.Tests.Fakes;

public sealed class FakeSeats : ISeats
{
    public string Sit()
    {
        return "fake seats";
    }
}
