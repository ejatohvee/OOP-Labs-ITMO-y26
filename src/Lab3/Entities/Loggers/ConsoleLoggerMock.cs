using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

public class ConsoleLoggerMock : ILogger
{
    public string OutputString { get; private set; } = string.Empty;

    public void Log(Message message)
    {
        OutputString += message.Header + Environment.NewLine + message.Body;
    }
}