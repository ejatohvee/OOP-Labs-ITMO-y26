using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Filters;

public interface IMessageFilter
{
    bool Filtrate(Message message, ImportanceLevels filterImportanceValue);
}