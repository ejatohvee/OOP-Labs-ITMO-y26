using Itmo.ObjectOrientedProgramming.Lab3.Entities.Filters;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class MessageFilterProxy : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ImportanceLevels _importanceLevel;
    private readonly MessageFilter _filter;

    public MessageFilterProxy(IAddressee addressee, ImportanceLevels importanceLevel, MessageFilter filter)
    {
        _addressee = addressee;
        _importanceLevel = importanceLevel;
        _filter = filter;
    }

    public void ReceiveMessage(Message message)
    {
        if (_filter.Filtrate(message, _importanceLevel))
        {
            _addressee.ReceiveMessage(message);
        }
    }
}