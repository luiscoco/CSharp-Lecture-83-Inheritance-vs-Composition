using InheritanceVsCompositionLab.Interfaces;

namespace InheritanceVsCompositionLab.Tests.Fakes;

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
