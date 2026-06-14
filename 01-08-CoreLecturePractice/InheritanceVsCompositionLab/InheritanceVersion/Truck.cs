namespace InheritanceVsCompositionLab.InheritanceVersion;

public sealed class Truck : Vehicle
{
    public Truck(string color, double weight, int maxSpeed)
        : base(color, weight, maxSpeed)
    {
    }

    public string LoadCargo()
    {
        return "The truck loads heavy cargo.";
    }
}
