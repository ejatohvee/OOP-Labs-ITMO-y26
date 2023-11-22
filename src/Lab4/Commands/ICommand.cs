using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    ExecutionResult Execute(GlobalContext context);
}