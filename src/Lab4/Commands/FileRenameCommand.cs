using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _newName;

    internal FileRenameCommand(string sourcePath, string newName)
    {
        _sourcePath = sourcePath;
        _newName = newName;
    }

    public ExecutionResult Execute(GlobalContext context)
    {
        try
        {
            context.FileSystem?.RenameFile(_sourcePath, _newName);
            return ExecutionResult.Success;
        }
        catch (IOException)
        {
            return ExecutionResult.Fail;
        }
    }
}