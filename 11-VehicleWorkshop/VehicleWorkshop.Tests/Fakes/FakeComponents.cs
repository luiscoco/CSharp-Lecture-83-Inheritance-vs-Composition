using VehicleWorkshop.Interfaces;

namespace VehicleWorkshop.Tests.Fakes;

public sealed class FakeEngine : IEngine
{
    private readonly string _message;

    public FakeEngine(string message)
    {
        _message = message;
    }

    public string Start() => _message;
}

public sealed class FakeBrakes : IBrakes
{
    public string Brake() => "fake brake";
}

public sealed class FakeSeats : ISeats
{
    public string Sit() => "fake seat";
}

public sealed class FakeWing : IWing
{
    public string Fly() => "fake fly";
}
