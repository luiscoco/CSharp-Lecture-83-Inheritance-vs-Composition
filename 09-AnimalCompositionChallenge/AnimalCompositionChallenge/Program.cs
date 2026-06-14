using AnimalCompositionChallenge;

Console.WriteLine("Bad inheritance example");
Console.WriteLine(new FlyingDog().Fly());
Console.WriteLine(new SwimmingBird().Swim());
Console.WriteLine(new RobotDog().ChargeBattery());

Console.WriteLine();
Console.WriteLine("Composition refactor");

var robotDog = new FlexibleAnimal(
    "Robot dog",
    new WalkCapability(),
    null,
    null,
    new BarkCapability(),
    new BatteryCapability());

var swimmingBird = new FlexibleAnimal(
    "Swimming bird",
    new WalkCapability(),
    new FlyCapability(),
    new SwimCapability(),
    null,
    null);

Console.WriteLine(robotDog.Describe());
Console.WriteLine(swimmingBird.Describe());
Console.WriteLine("The refactor avoids inheritance explosion because capabilities can be combined without creating a subclass for every combination.");
