using System;
using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileShowCommand;

public class FileShowCommandHandler : BaseHandler
{
    private const string FileCopyCommandName = "show";
    private readonly IFileShowArgumentHandler _handler;

    public FileShowCommandHandler(IFileShowArgumentHandler handler)
        : base(FileCopyCommandName)
    {
        _handler = handler;
    }

    public override ICommand? Handle(IEnumerator request)
    {
        var commandBuilder = new FileShowCommandBuilder();
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