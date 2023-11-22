using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class FileCopyCommandBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public FileCopyCommandBuilder()
    {
        _sourcePath = null;
        _destinationPath = null;
    }

    public FileCopyCommandBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public FileCopyCommandBuilder WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public FileCopyCommand Build()
    {
        return new FileCopyCommand(
            _sourcePath ?? throw new InvalidOperationException(),
            _destinationPath ?? throw new InvalidOperationException());
    }
}