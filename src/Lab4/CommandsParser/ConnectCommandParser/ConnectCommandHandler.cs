using System;
using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.ConnectCommandParser;

public class ConnectCommandHandler : BaseHandler
{
    private const string FileCopyCommandName = "connect";
    private readonly IConnectArgumentHandler _handler;

    public ConnectCommandHandler(IConnectArgumentHandler handler)
        : base(FileCopyCommandName)
    {
        _handler = handler;
    }

    public override ICommand? Handle(IEnumerator request)
    {
        var commandBuilder = new ConnectCommandBuilder();
        if (!request.MoveNext()) return null;
        _handler.Handle(request, commandBuilder);
        try
        {
            return commandBuilder.Build();
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }
}