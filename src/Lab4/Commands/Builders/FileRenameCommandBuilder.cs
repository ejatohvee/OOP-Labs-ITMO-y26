using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class FileRenameCommandBuilder
{
    private string? _sourcePath;
    private string? _newName;

    public FileRenameCommandBuilder()
    {
        _sourcePath = null;
        _newName = null;
    }

    public FileRenameCommandBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public FileRenameCommandBuilder WithNewName(string newName)
    {
        _newName = newName;
        return this;
    }

    public FileRenameCommand Build()
    {
        return new FileRenameCommand(
            _sourcePath ?? throw new InvalidOperationException(),
            _newName ?? throw new InvalidOperationException());
    }
}