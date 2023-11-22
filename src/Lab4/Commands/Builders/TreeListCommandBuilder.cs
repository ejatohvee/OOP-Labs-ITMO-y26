using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class TreeListCommandBuilder
{
    private int? _selectionDepth;
    public TreeListCommandBuilder()
    {
        _selectionDepth = null;
    }

    public TreeListCommandBuilder(int selectionDepth)
    {
        _selectionDepth = selectionDepth;
    }

    public TreeListCommandBuilder WithSelectionDepth(int selectionDepth)
    {
        _selectionDepth = selectionDepth;
        return this;
    }

    public TreeListCommand Build()
    {
        return new TreeListCommand(
            _selectionDepth ?? throw new InvalidOperationException());
    }
}