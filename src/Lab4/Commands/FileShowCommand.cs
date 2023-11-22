using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowCommand : ICommand
{
    private readonly string _filePath;
    private readonly FileShowMode _showMode;

    internal FileShowCommand(string filePath, FileShowMode showMode)
    {
        _filePath = filePath;
        _showMode = showMode;
    }

    public ExecutionResult Execute(GlobalContext context)
    {
        try
        {
            context.FileSystem?.FileShow(_filePath, _showMode);
            return ExecutionResult.Success;
        }
        catch (IOException)
        {
            return ExecutionResult.Fail;
        }
    }
}