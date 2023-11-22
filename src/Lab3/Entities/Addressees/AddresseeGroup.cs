using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeGroup : IAddressee
{
    private ReadOnlyCollection<IAddressee> _addressees;

    public AddresseeGroup(ReadOnlyCollection<IAddressee> addresees)
    {
        _addressees = addresees;
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.ReceiveMessage(message);
        }
    }
}