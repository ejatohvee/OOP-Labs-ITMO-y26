namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public class MessengerMock : IMessenger
{
    public string OutputString { get; private set; } = string.Empty;

    public void PrintMessage(string message)
    {
        OutputString += message;
    }
}