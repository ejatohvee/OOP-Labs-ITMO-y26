using System;
using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileRenameCommand;

public class FileRenameCommandHandler : BaseHandler
{
    private const string FileCopyCommandName = "rename";
    private readonly IFileRenameArgumentHandler _handler;

    public FileRenameCommandHandler(IFileRenameArgumentHandler handler)
        : base(FileCopyCommandName)
    {
        _handler = handler;
    }

    public override ICommand? Handle(IEnumerator request)
    {
        var commandBuilder = new FileRenameCommandBuilder();
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