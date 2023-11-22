using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _address;
    private readonly ConnectonMode _mode;

    public ConnectCommand(string address, ConnectonMode mode)
    {
        _address = address;
        _mode = mode;
    }

    public ExecutionResult Execute(GlobalContext context)
    {
        try
        {
            context.FileSystem.Connect(_address, _mode);
            return ExecutionResult.Success;
        }
        catch (InvalidOperationException)
        {
            return ExecutionResult.Fail;
        }
    }
}