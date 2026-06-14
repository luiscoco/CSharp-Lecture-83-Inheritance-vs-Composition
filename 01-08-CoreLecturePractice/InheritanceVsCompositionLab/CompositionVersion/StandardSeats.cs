using InheritanceVsCompositionLab.Interfaces;

namespace InheritanceVsCompositionLab.CompositionVersion;

public sealed class StandardSeats : ISeats
{
    public string Sit()
    {
        return "Standard seats are comfortable for daily driving.";
    }
}
