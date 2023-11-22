using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileMoveCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    internal FileMoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public ExecutionResult Execute(GlobalContext context)
    {
        try
        {
            context.FileSystem?.MoveFile(_sourcePath, _destinationPath);
            return ExecutionResult.Success;
        }
        catch (IOException)
        {
            return ExecutionResult.Fail;
        }
    }
}