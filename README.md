# Lecture 83: Inheritance vs Composition

This workspace contains a sequence of beginner-friendly C# projects and documents that teach how inheritance works, why it can become fragile, and how composition with interfaces solves many real design problems.

Run everything from the root folder:

```powershell
dotnet test InheritanceVsCompositionPractice.slnx
```

## Project Map

| Step | Folder | Purpose |
| --- | --- | --- |
| 01-08 | `01-08-CoreLecturePractice` | Main lecture lab: project setup, inheritance, inheritance trap, composition, interfaces, runtime swapping, tests, and ADR |
| 09 | `09-AnimalCompositionChallenge` | Reinforcement challenge showing inheritance explosion with animals |
| 10 | `10-ProfessionalReview` | Senior architect review and top improvements |
| 11 | `11-VehicleWorkshop` | Final mini-project using composition professionally |
| 12 | `12-InterviewQuestions` | Interview questions and answers |

## 01. Project Setup

The first project is a .NET 10 console application named `InheritanceVsCompositionLab`.

Important folders:

- `InheritanceVersion`: inheritance-based vehicle example
- `CompositionVersion`: component-based vehicle example
- `Interfaces`: contracts for replaceable behavior
- `Demo`: console walkthrough
- `Docs`: architecture decision record
- `InheritanceVsCompositionLab.Tests`: xUnit tests

The entry point stays small:

```csharp
using InheritanceVsCompositionLab.Demo;

DemoRunner.Run();
```

Conceptual goal: keep the application structure clean so students can focus on the design difference, not on framework complexity.

## 02. Basic Inheritance Exercise

The inheritance version starts with one base class:

```csharp
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

    public string Move()
    {
        return $"{GetType().Name} moves using shared Vehicle behavior.";
    }
}
```

Then child classes reuse the shared state and behavior:

```csharp
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
```

Teaching point: this is an **is-a** relationship. A `Car` is a `Vehicle`, a `Truck` is a `Vehicle`, and a `Lambo` is a `Vehicle`.

## 03. Identify The Inheritance Trap

Inheritance looks clean while the model is small. It becomes fragile when requirements grow:

- Electric cars
- Flying cars
- Boats
- Amphibious vehicles
- Different engines, brakes, seats, and wings

The code includes this warning comment in the base class:

```csharp
// Inheritance trap: adding ElectricCar, FlyingCar, AmphibiousTruck, and many
// engine/brake/seat/wing combinations can force this base class to know too much.
```

Teaching point: inheritance becomes risky when independent features are forced into one hierarchy. You can end up with classes like `FlyingElectricCar`, `AmphibiousTruck`, and `FlyingElectricSportsCar`.

## 04. Refactor To Composition

Composition replaces "what subclass am I?" with "what parts do I have?"

The composed vehicle receives its parts through the constructor:

```csharp
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
}
```

Teaching point: this is a **has-a** relationship. A vehicle has an engine, has brakes, has seats, and may have a wing.

## 05. Introduce Interfaces

Interfaces define small capabilities:

```csharp
public interface IEngine
{
    string Start();
}

public interface IBrakes
{
    string Brake();
}

public interface ISeats
{
    string Sit();
}

public interface IWing
{
    string Fly();
}
```

Concrete implementations can then vary independently:

```csharp
public sealed class ElectricEngine : IEngine
{
    public string Start()
    {
        return "Electric engine starts silently.";
    }
}
```

Teaching point: `Vehicle` no longer depends on one specific engine class. It depends on the `IEngine` contract.

## 06. Runtime Swapping

Composition makes runtime replacement straightforward:

```csharp
public void ReplaceEngine(IEngine engine)
{
    _engine = engine;
}
```

The demo shows the behavior:

```csharp
Console.WriteLine(dailyCar.Start());
dailyCar.ReplaceEngine(new ElectricEngine());
Console.WriteLine(dailyCar.Start());
```

Teaching point: with rigid inheritance, an object cannot easily change from `CombustionCar` into `ElectricCar`. With composition, the vehicle keeps its identity and swaps one part.

## 07. Testability Practice

The tests use fake components instead of real ones:

```csharp
public sealed class FakeEngine : IEngine
{
    private readonly string _message;

    public FakeEngine(string message)
    {
        _message = message;
    }

    public int StartCount { get; private set; }

    public string Start()
    {
        StartCount++;
        return _message;
    }
}
```

The vehicle can be tested in isolation:

```csharp
var engine = new FakeEngine("fake engine starts");
var vehicle = new Vehicle("Test vehicle", engine, new FakeBrakes(), new FakeSeats());

var result = vehicle.Start();

Assert.Equal("Test vehicle: fake engine starts", result);
Assert.Equal(1, engine.StartCount);
```

Teaching point: composition improves testability because dependencies can be replaced with fakes.

## 08. Architecture Decision Record

The ADR is here:

```text
01-08-CoreLecturePractice/InheritanceVsCompositionLab/Docs/ADR-001-Inheritance-vs-Composition.md
```

Main decision:

```text
Use simple inheritance for the beginner demonstration, but use composition for the flexible vehicle model.
```

Teaching point: an ADR captures why the design changed, not just what code was written.

## 09. Favor Composition Refactoring Challenge

The animal challenge starts with a bad inheritance model:

```csharp
public class Animal { }
public class Dog : Animal { }
public class Bird : Animal { }
public sealed class FlyingDog : Dog { }
public sealed class SwimmingBird : Bird { }
public sealed class RobotDog : Dog { }
```

Then it refactors behavior into capabilities:

```csharp
public interface IWalk { string Walk(); }
public interface IFly { string Fly(); }
public interface ISwim { string Swim(); }
public interface IBark { string Bark(); }
public interface IChargeBattery { string ChargeBattery(); }
```

The flexible animal receives only the capabilities it needs:

```csharp
var robotDog = new FlexibleAnimal(
    "Robot dog",
    new WalkCapability(),
    null,
    null,
    new BarkCapability(),
    new BatteryCapability());
```

Teaching point: composition avoids inheritance explosion because capabilities can be mixed without creating a subclass for every combination.

## 10. Professional Review

The review is here:

```text
10-ProfessionalReview/ProfessionalReview.md
```

It evaluates:

- Class design
- Coupling
- Maintainability
- Testability
- Use of interfaces
- Whether inheritance is justified
- Whether composition is overused

Top improvements applied:

1. Component methods return strings instead of writing directly to the console.
2. Wings are optional.
3. Engine replacement is explicit through `ReplaceEngine`.

Teaching point: professional review is not only about finding mistakes. It is about improving coupling, testability, and change tolerance.

## 11. Final Mini-Project: VehicleWorkshop

VehicleWorkshop is the portfolio-quality version of the lesson.

Example vehicles are assembled in `VehicleFactory`:

```csharp
public static IReadOnlyList<Vehicle> CreateExamples()
{
    return
    [
        new Vehicle("City commuter", new ElectricEngine(), new StandardBrakes(), new StandardSeats()),
        new Vehicle("Track car", new CombustionEngine(), new SportBrakes(), new RacingSeats()),
        new Vehicle("Work truck", new CombustionEngine(), new HeavyDutyBrakes(), new UtilitySeats()),
        new Vehicle("Hybrid tourer", new HybridEngine(), new StandardBrakes(), new StandardSeats()),
        new Vehicle("Flying prototype", new HybridEngine(), new SportBrakes(), new RacingSeats(), new FoldingWing())
    ];
}
```

The final vehicle model stays simple:

```csharp
public sealed class Vehicle
{
    public string Name { get; }
    public IEngine Engine { get; private set; }
    public IBrakes Brakes { get; }
    public ISeats Seats { get; }
    public IWing? Wing { get; }

    public string Start() => $"{Name}: {Engine.Start()}";
    public string Stop() => $"{Name}: {Brakes.Brake()}";
    public string Enter() => $"{Name}: {Seats.Sit()}";
}
```

Teaching point: this is the same concept as the lecture lab, but organized as a small real project with examples, tests, and a local README.

## 12. Exam-Style Questions

The interview questions are here:

```text
12-InterviewQuestions/InheritanceVsCompositionQuestions.md
```

They cover:

- Beginner definitions
- Intermediate design tradeoffs
- Architecture-level judgment
- Code review
- Refactoring

Example question:

```text
A teammate adds FlyingElectricTruckWithRacingSeats : Truck.
What should you suggest, and how would you refactor it?
```

Expected answer: move independently varying behavior into components such as `IEngine`, `ISeats`, and `IWing`, then inject concrete implementations into a composed `Vehicle`.

## Teaching Sequence

Use this order in class:

1. Start with inheritance because it is simple and familiar.
2. Show where inheritance works: stable `is-a` relationships.
3. Add changing requirements to reveal subclass explosion.
4. Refactor to composition with concrete components.
5. Add interfaces to reduce coupling.
6. Swap behavior at runtime.
7. Write isolated tests with fakes.
8. Capture the decision in an ADR.
9. Reinforce the idea with the animal challenge.
10. Review the design like a senior engineer.
11. Study VehicleWorkshop as the final project.
12. Use the interview questions for exam practice.

## Key Rule Of Thumb

Use inheritance when the relationship is truly **is-a** and the hierarchy is stable.

Prefer composition when behavior changes independently, needs to be swapped, reused in different combinations, or tested in isolation.
