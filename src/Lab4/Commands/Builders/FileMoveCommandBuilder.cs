using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class FileMoveCommandBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public FileMoveCommandBuilder()
    {
        _sourcePath = null;
        _destinationPath = null;
    }

    public FileMoveCommandBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public FileMoveCommandBuilder WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public FileMoveCommand Build()
    {
        return new FileMoveCommand(
            _sourcePath ?? throw new InvalidOperationException(),
            _destinationPath ?? throw new InvalidOperationException());
    }
}