namespace AnimalCompositionChallenge;

public class Animal
{
    public string Eat()
    {
        return "Animal eats.";
    }
}

public class Dog : Animal
{
    public string Bark()
    {
        return "Dog barks.";
    }
}

public class Bird : Animal
{
    public string Fly()
    {
        return "Bird flies.";
    }
}

public sealed class FlyingDog : Dog
{
    public string Fly()
    {
        return "Flying dog flies.";
    }
}

public sealed class SwimmingBird : Bird
{
    public string Swim()
    {
        return "Swimming bird swims.";
    }
}

public sealed class RobotDog : Dog
{
    public string ChargeBattery()
    {
        return "Robot dog charges its battery.";
    }
}

public interface IWalk
{
    string Walk();
}

public interface IFly
{
    string Fly();
}

public interface ISwim
{
    string Swim();
}

public interface IBark
{
    string Bark();
}

public interface IChargeBattery
{
    string ChargeBattery();
}

public sealed class WalkCapability : IWalk
{
    public string Walk() => "walks";
}

public sealed class FlyCapability : IFly
{
    public string Fly() => "flies";
}

public sealed class SwimCapability : ISwim
{
    public string Swim() => "swims";
}

public sealed class BarkCapability : IBark
{
    public string Bark() => "barks";
}

public sealed class BatteryCapability : IChargeBattery
{
    public string ChargeBattery() => "charges battery";
}

public sealed class FlexibleAnimal
{
    private readonly IWalk? _walk;
    private readonly IFly? _fly;
    private readonly ISwim? _swim;
    private readonly IBark? _bark;
    private readonly IChargeBattery? _battery;

    public FlexibleAnimal(string name, IWalk? walk, IFly? fly, ISwim? swim, IBark? bark, IChargeBattery? battery)
    {
        Name = name;
        _walk = walk;
        _fly = fly;
        _swim = swim;
        _bark = bark;
        _battery = battery;
    }

    public string Name { get; }

    public string Describe()
    {
        var abilities = new List<string>();

        if (_walk is not null) abilities.Add(_walk.Walk());
        if (_fly is not null) abilities.Add(_fly.Fly());
        if (_swim is not null) abilities.Add(_swim.Swim());
        if (_bark is not null) abilities.Add(_bark.Bark());
        if (_battery is not null) abilities.Add(_battery.ChargeBattery());

        return $"{Name}: {string.Join(", ", abilities)}.";
    }
}
