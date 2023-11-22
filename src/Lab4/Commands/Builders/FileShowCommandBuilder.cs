using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class FileShowCommandBuilder
{
    private string? _filePath;
    private FileShowMode? _showMode;

    public FileShowCommandBuilder()
    {
        _showMode = null;
        _filePath = null;
    }

    public FileShowCommandBuilder WithFilePath(string filePath)
    {
        _filePath = filePath;
        return this;
    }

    public FileShowCommandBuilder WithShowMode(FileShowMode showMode)
    {
        _showMode = showMode;
        return this;
    }

    public FileShowCommand Build()
    {
        return new FileShowCommand(
            _filePath ?? throw new InvalidOperationException(),
            _showMode ?? throw new InvalidOperationException());
    }
}