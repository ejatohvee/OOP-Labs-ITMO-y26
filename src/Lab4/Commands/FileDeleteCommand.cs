using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly string _filePath;

    internal FileDeleteCommand(string filePath)
    {
        _filePath = filePath;
    }

    public ExecutionResult Execute(GlobalContext context)
    {
        try
        {
            context.FileSystem?.DeleteFile(_filePath);
            return ExecutionResult.Success;
        }
        catch (IOException)
        {
            return ExecutionResult.Fail;
        }
    }
}