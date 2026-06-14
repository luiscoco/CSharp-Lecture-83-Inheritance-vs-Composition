# VehicleWorkshop

VehicleWorkshop is a beginner-friendly mini-project showing why C# developers often favor composition over deep inheritance.

## What The App Does

Users can create vehicles by combining components:

- Engines: combustion, electric, hybrid
- Brakes: standard, sport, heavy-duty
- Seats: standard, racing, utility
- Wings: optional fixed or folding wings

The project includes at least five example vehicles in `VehicleFactory`.

## Inheritance Example

An inheritance model might create classes such as `Car`, `Truck`, `ElectricCar`, `FlyingCar`, and `FlyingElectricCar`.

That works while the hierarchy is small, but it becomes harder to maintain when features can be combined in many ways.

## Composition Example

VehicleWorkshop uses this shape instead:

```csharp
var vehicle = new Vehicle(
    "Flying prototype",
    new HybridEngine(),
    new SportBrakes(),
    new RacingSeats(),
    new FoldingWing());
```

This is a "has-a" relationship:

- A vehicle has an engine.
- A vehicle has brakes.
- A vehicle has seats.
- A vehicle may have a wing.

## Why This Is Easier To Test

Tests can inject fake engines, brakes, seats, and wings. The `Vehicle` class can be tested by itself without depending on concrete component classes.
