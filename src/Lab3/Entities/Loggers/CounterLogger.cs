using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

public class CounterLogger : ILogger
{
    private readonly ILogger _originalLogger;

    public CounterLogger(ILogger originalLogger)
    {
        _originalLogger = originalLogger;
    }

    public int CallCount { get; set; }

    public void Log(Message message)
    {
        CallCount++;
        _originalLogger.Log(message);
    }
}