namespace InheritanceVsCompositionLab.InheritanceVersion;

public sealed class Lambo : Vehicle
{
    public Lambo(string color, double weight, int maxSpeed)
        : base(color, weight, maxSpeed)
    {
    }

    public string EnableTrackMode()
    {
        return "The Lambo enables track mode.";
    }
}
