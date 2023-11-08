using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

public class ConsoleLogger : ILogger
{
    public void Log(Message message)
    {
        message.Render();
    }
}