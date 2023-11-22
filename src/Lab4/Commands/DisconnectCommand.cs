using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    public ExecutionResult Execute(GlobalContext context)
    {
        try
        {
            context.FileSystem.Disconnect();
            return ExecutionResult.Success;
        }
        catch (InvalidOperationException)
        {
            return ExecutionResult.Fail;
        }
    }
}