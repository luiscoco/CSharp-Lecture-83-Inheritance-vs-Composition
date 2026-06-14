# Interview Questions: Inheritance vs Composition In C#

## Beginner

1. **What is inheritance in C#?**  
   Inheritance lets one class reuse and specialize another class. In the lab, `Car` inherits from `Vehicle`.

2. **What is composition in C#?**  
   Composition builds a class from smaller objects. In VehicleWorkshop, a `Vehicle` has an `IEngine`, `IBrakes`, `ISeats`, and optional `IWing`.

3. **What does "is-a" mean?**  
   It means one type is a specialized form of another type. A `Car` is a `Vehicle`.

4. **What does "has-a" mean?**  
   It means one object owns or uses another object. A VehicleWorkshop `Vehicle` has an engine.

## Intermediate

5. **Why can inheritance become fragile?**  
   When features vary independently, subclasses multiply. `FlyingElectricSportsCar` style classes become hard to maintain.

6. **How do interfaces help composition?**  
   Interfaces let `Vehicle` depend on capabilities such as `IEngine` instead of concrete classes such as `ElectricEngine`.

7. **Why is runtime swapping easier with composition?**  
   VehicleWorkshop can call `ReplaceEngine(new ElectricEngine())`. With rigid inheritance, an object cannot change from one subclass into another.

## Architecture

8. **When is inheritance justified?**  
   Use it when the relationship is truly "is-a", behavior is stable, and the hierarchy is small.

9. **When can composition be overused?**  
   Composition is overused when every tiny value becomes an interface without a real need for replacement, testing, or independent variation.

## Code Review And Refactoring

10. **A teammate adds `FlyingElectricTruckWithRacingSeats : Truck`. What should you suggest, and how would you refactor it?**  
    Suggest moving engine, wing, and seat choices into components like VehicleWorkshop does, because those features vary independently. Create interfaces such as `IEngine`, `ISeats`, and `IWing`, then inject concrete components into a `Vehicle` constructor.
