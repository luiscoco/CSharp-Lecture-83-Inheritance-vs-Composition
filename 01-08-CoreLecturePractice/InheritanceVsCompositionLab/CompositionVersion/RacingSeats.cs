using InheritanceVsCompositionLab.Interfaces;

namespace InheritanceVsCompositionLab.CompositionVersion;

public sealed class RacingSeats : ISeats
{
    public string Sit()
    {
        return "Racing seats hold the driver firmly.";
    }
}
