using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Filters;

public class MessageFilter : IMessageFilter
{
    public bool Filtrate(Message message, ImportanceLevels filterImportanceValue)
    {
        return message.ImportanceLevel.Level >= filterImportanceValue.Level;
    }
}