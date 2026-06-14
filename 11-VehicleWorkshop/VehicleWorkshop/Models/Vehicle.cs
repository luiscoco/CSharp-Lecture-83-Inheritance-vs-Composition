using VehicleWorkshop.Interfaces;

namespace VehicleWorkshop.Models;

public sealed class Vehicle
{
    public Vehicle(string name, IEngine engine, IBrakes brakes, ISeats seats, IWing? wing = null)
    {
        Name = name;
        Engine = engine;
        Brakes = brakes;
        Seats = seats;
        Wing = wing;
    }

    public string Name { get; }
    public IEngine Engine { get; private set; }
    public IBrakes Brakes { get; }
    public ISeats Seats { get; }
    public IWing? Wing { get; }

    public string Start() => $"{Name}: {Engine.Start()}";

    public string Stop() => $"{Name}: {Brakes.Brake()}";

    public string Enter() => $"{Name}: {Seats.Sit()}";

    public string Fly() => Wing is null
        ? $"{Name}: no wing installed"
        : $"{Name}: {Wing.Fly()}";

    public void ReplaceEngine(IEngine engine)
    {
        Engine = engine;
    }
}
