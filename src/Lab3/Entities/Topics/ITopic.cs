using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public interface ITopic
{
    public void TransferMessage(Message message);
}