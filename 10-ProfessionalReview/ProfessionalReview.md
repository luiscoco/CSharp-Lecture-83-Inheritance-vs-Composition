# Professional Review: InheritanceVsCompositionLab

## Findings

1. The inheritance version is justified only as a teaching example. It models a clear `Car is a Vehicle` relationship, but it should not be extended into a production vehicle feature matrix.
2. The composition version has lower coupling because `Vehicle` depends on interfaces instead of concrete engine, brake, seat, and wing classes.
3. Testability is strongest in the composition version because fake components can be injected without starting real engines or using console output.
4. Composition is not overused here. The components represent behavior that changes independently.
5. The main maintainability risk is allowing optional capabilities to grow into many nullable properties. If many optional capabilities appear, group them behind a collection or capability registry.

## Top Three Improvements Applied

1. Component methods return strings instead of writing directly to the console, which makes behavior easy to test.
2. The wing is optional, so normal ground vehicles do not need a fake or meaningless wing implementation.
3. Runtime engine replacement is represented by a single `ReplaceEngine` method, keeping mutation explicit instead of exposing all component fields.
