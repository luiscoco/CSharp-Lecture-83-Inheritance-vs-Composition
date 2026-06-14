# ADR-001: Inheritance vs Composition

## Context

The first version models vehicles with inheritance: `Car`, `Truck`, and `Lambo` inherit shared state and behavior from `Vehicle`.

The requirements then grow to include electric cars, flying cars, boats, amphibious vehicles, and many interchangeable engines, brakes, seats, and wings.

## Decision

Use simple inheritance for the beginner demonstration, but use composition for the flexible vehicle model.

## Why Inheritance Was Useful At First

Inheritance made the original example easy to understand. A `Car` is a `Vehicle`, so it can reuse common properties such as color, weight, and max speed.

## Why Composition Became Better As Requirements Grew

When features vary independently, inheritance creates too many subclasses. Composition lets a vehicle have an engine, brakes, seats, and optional wing without creating a new class for every combination.

## Consequences

Composition adds a few more small types and interfaces, but it reduces coupling and makes the system easier to extend and test.

## Rule Of Thumb

Use inheritance when the relationship is truly "is-a" and the hierarchy is stable. Prefer composition when behavior changes independently or needs to be swapped, tested, or reused in many combinations.
