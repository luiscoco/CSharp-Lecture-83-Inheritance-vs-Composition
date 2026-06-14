namespace InheritanceVsCompositionLab.InheritanceVersion;

public abstract class Vehicle
{
    protected Vehicle(string color, double weight, int maxSpeed)
    {
        Color = color;
        Weight = weight;
        MaxSpeed = maxSpeed;
    }

    public string Color { get; }
    public double Weight { get; }
    public int MaxSpeed { get; }

    public string Describe()
    {
        return $"{GetType().Name}: {Color}, {Weight} kg, max {MaxSpeed} km/h";
    }

    public string Move()
    {
        return $"{GetType().Name} moves using shared Vehicle behavior.";
    }

    // Inheritance trap: adding ElectricCar, FlyingCar, AmphibiousTruck, and many
    // engine/brake/seat/wing combinations can force this base class to know too much.
}
