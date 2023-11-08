using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class MessengerAddresseeAdapter : IAddressee
{
    private readonly IMessenger _messenger;

    public MessengerAddresseeAdapter(IMessenger message)
    {
        _messenger = message;
    }

    public void ReceiveMessage(Message message)
    {
        _messenger.PrintMessage($"{message.Header}\n{message.Body}");
    }
}