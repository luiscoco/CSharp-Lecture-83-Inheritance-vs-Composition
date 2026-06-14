namespace InheritanceVsCompositionLab.InheritanceVersion;

public sealed class Car : Vehicle
{
    public Car(string color, double weight, int maxSpeed)
        : base(color, weight, maxSpeed)
    {
    }

    public string OpenTrunk()
    {
        return "The car opens its trunk.";
    }
}
