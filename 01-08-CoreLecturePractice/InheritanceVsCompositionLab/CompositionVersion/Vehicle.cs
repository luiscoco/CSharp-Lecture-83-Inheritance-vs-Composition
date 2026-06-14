using InheritanceVsCompositionLab.Interfaces;

namespace InheritanceVsCompositionLab.CompositionVersion;

public sealed class Vehicle
{
    private IEngine _engine;
    private readonly IBrakes _brakes;
    private readonly ISeats _seats;
    private readonly IWing? _wing;

    public Vehicle(string name, IEngine engine, IBrakes brakes, ISeats seats, IWing? wing = null)
    {
        Name = name;
        _engine = engine;
        _brakes = brakes;
        _seats = seats;
        _wing = wing;
    }

    public string Name { get; }

    public string Start()
    {
        return $"{Name}: {_engine.Start()}";
    }

    public string Brake()
    {
        return $"{Name}: {_brakes.Brake()}";
    }

    public string Sit()
    {
        return $"{Name}: {_seats.Sit()}";
    }

    public string Fly()
    {
        return _wing is null
            ? $"{Name}: this vehicle has no wing."
            : $"{Name}: {_wing.Fly()}";
    }

    public void ReplaceEngine(IEngine engine)
    {
        _engine = engine;
    }
}
