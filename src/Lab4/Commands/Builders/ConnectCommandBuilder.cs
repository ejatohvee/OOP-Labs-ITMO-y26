using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class ConnectCommandBuilder
{
    private string? _address;
    private ConnectonMode? _mode;

    public ConnectCommandBuilder()
    {
        _address = null;
        _mode = null;
    }

    public ConnectCommandBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }

    public ConnectCommandBuilder WithMode(ConnectonMode mode)
    {
        _mode = mode;
        return this;
    }

    public ConnectCommand Build()
    {
        return new ConnectCommand(
            _address ?? throw new InvalidOperationException(),
            _mode ?? throw new InvalidOperationException());
    }
}