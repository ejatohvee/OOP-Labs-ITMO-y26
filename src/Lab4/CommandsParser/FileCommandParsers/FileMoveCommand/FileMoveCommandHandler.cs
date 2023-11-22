using System;
using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileMoveCommand;

public class FileMoveCommandHandler : BaseHandler
{
    private const string FileCopyCommandName = "move";
    private readonly IFileMoveArgumentHandler _handler;

    public FileMoveCommandHandler(IFileMoveArgumentHandler handler)
        : base(FileCopyCommandName)
    {
        _handler = handler;
    }

    public override ICommand? Handle(IEnumerator request)
    {
        var commandBuilder = new FileMoveCommandBuilder();
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