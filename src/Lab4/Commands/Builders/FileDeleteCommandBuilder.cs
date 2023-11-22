using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class FileDeleteCommandBuilder
{
    private string? _filePath;

    public FileDeleteCommandBuilder()
    {
        _filePath = null;
    }

    public FileDeleteCommandBuilder WithFilePath(string filePath)
    {
        _filePath = filePath;
        return this;
    }

    public FileDeleteCommand Build()
    {
        return new FileDeleteCommand(
            _filePath ?? throw new InvalidOperationException());
    }
}