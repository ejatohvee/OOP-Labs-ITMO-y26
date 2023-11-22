using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGoToCommand : ICommand
{
    private readonly string _path;

    public TreeGoToCommand(string path)
    {
        _path = path;
    }

    public ExecutionResult Execute(GlobalContext context)
    {
        try
        {
            context.FileSystem.TreeGoTo(_path);
            return ExecutionResult.Success;
        }
        catch (InvalidOperationException)
        {
            return ExecutionResult.Fail;
        }
    }
}