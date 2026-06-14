using InheritanceVsCompositionLab.CompositionVersion;
using InheritanceVsCompositionLab.Tests.Fakes;

namespace InheritanceVsCompositionLab.Tests;

public sealed class VehicleCompositionTests
{
    [Fact]
    public void Start_UsesInjectedEngine()
    {
        var engine = new FakeEngine("fake engine starts");
        var vehicle = new Vehicle("Test vehicle", engine, new FakeBrakes(), new FakeSeats());

        var result = vehicle.Start();

        Assert.Equal("Test vehicle: fake engine starts", result);
        Assert.Equal(1, engine.StartCount);
    }

    [Fact]
    public void ReplaceEngine_UsesNewEngineAtRuntime()
    {
        var firstEngine = new FakeEngine("first engine");
        var secondEngine = new FakeEngine("second engine");
        var vehicle = new Vehicle("Swap vehicle", firstEngine, new FakeBrakes(), new FakeSeats());

        vehicle.ReplaceEngine(secondEngine);

        Assert.Equal("Swap vehicle: second engine", vehicle.Start());
        Assert.Equal(0, firstEngine.StartCount);
        Assert.Equal(1, secondEngine.StartCount);
    }

    [Fact]
    public void Fly_ReturnsClearMessageWhenNoWingExists()
    {
        var vehicle = new Vehicle("Ground vehicle", new FakeEngine("engine"), new FakeBrakes(), new FakeSeats());

        Assert.Equal("Ground vehicle: this vehicle has no wing.", vehicle.Fly());
    }

    [Fact]
    public void Fly_UsesInjectedWingWhenProvided()
    {
        var vehicle = new Vehicle("Winged vehicle", new FakeEngine("engine"), new FakeBrakes(), new FakeSeats(), new FakeWing());

        Assert.Equal("Winged vehicle: fake wing", vehicle.Fly());
    }
}
