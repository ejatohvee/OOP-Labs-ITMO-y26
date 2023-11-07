using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeConsoleLogger : IAddressee
{
    private readonly IAddressee _decoratee;
    private readonly ILogger _logger;

    public AddresseeConsoleLogger(IAddressee decoratee, ILogger logger)
    {
        _decoratee = decoratee;
        _logger = logger;
    }

    public void ReceiveMessage(Message message)
    {
        _logger.Log(message);
        _decoratee.ReceiveMessage(message);
    }
}