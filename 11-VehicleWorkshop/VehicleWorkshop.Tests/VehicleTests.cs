using VehicleWorkshop.Demo;
using VehicleWorkshop.Models;
using VehicleWorkshop.Tests.Fakes;

namespace VehicleWorkshop.Tests;

public sealed class VehicleTests
{
    [Fact]
    public void Vehicle_UsesInjectedComponents()
    {
        var vehicle = new Vehicle("Test build", new FakeEngine("fake start"), new FakeBrakes(), new FakeSeats(), new FakeWing());

        Assert.Equal("Test build: fake start", vehicle.Start());
        Assert.Equal("Test build: fake brake", vehicle.Stop());
        Assert.Equal("Test build: fake seat", vehicle.Enter());
        Assert.Equal("Test build: fake fly", vehicle.Fly());
    }

    [Fact]
    public void Vehicle_CanReplaceEngine()
    {
        var vehicle = new Vehicle("Swap build", new FakeEngine("old"), new FakeBrakes(), new FakeSeats());

        vehicle.ReplaceEngine(new FakeEngine("new"));

        Assert.Equal("Swap build: new", vehicle.Start());
    }

    [Fact]
    public void Factory_CreatesAtLeastFiveVehicles()
    {
        var vehicles = VehicleFactory.CreateExamples();

        Assert.True(vehicles.Count >= 5);
    }
}
