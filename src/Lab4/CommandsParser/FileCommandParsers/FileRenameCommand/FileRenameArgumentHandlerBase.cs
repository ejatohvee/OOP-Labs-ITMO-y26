using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileRenameCommand;

public abstract class FileRenameArgumentHandlerBase : IFileRenameArgumentHandler
{
    protected IFileRenameArgumentHandler? Next { get; private set; }

    public void AddNext(IFileRenameArgumentHandler link)
    {
        if (Next is null)
        {
            Next = link;
        }
        else
        {
            Next.AddNext(link);
        }
    }

    public abstract FileRenameCommandBuilder Handle(IEnumerator enumerator, FileRenameCommandBuilder builder);
}