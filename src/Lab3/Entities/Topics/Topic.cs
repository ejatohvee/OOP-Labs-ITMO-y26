using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic : ITopic
{
    private IAddressee _addressee;

    public Topic(IAddressee addressee, string title)
    {
        _addressee = addressee;
        Title = title;
    }

    public string Title { get; set; }

    public void TransferMessage(Message message)
    {
        _addressee.ReceiveMessage(message);
    }
}
