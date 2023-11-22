using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private readonly int _selectionDepth;

    public TreeListCommand(int selectionDepth)
    {
        _selectionDepth = selectionDepth;
    }

    public ExecutionResult Execute(GlobalContext context)
    {
        try
        {
            context.FileSystem.TreeList(_selectionDepth);
            return ExecutionResult.Success;
        }
        catch (IOException)
        {
            return ExecutionResult.Fail;
        }
    }
}