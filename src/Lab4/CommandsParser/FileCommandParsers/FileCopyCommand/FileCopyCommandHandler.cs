using System;
using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileCopyCommand;

public class FileCopyCommandHandler : BaseHandler
{
    private const string FileCopyCommandName = "copy";
    private readonly IFileCopyArgumentHandler _handler;

    public FileCopyCommandHandler(IFileCopyArgumentHandler handler)
        : base(FileCopyCommandName)
    {
        _handler = handler;
    }

    public override ICommand? Handle(IEnumerator request)
    {
        var commandBuilder = new FileCopyCommandBuilder();
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