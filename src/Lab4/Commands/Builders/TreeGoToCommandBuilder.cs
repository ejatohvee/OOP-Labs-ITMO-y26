using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class TreeGoToCommandBuilder
{
    private string? _path;

    public TreeGoToCommandBuilder()
    {
        _path = null;
    }

    public TreeGoToCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public TreeGoToCommand Build()
    {
        return new TreeGoToCommand(
            _path ?? throw new InvalidOperationException());
    }
}