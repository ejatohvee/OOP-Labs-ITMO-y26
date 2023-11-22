using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileShowCommand;

public abstract class FileShowArgumentHandlerBase : IFileShowArgumentHandler
{
    protected IFileShowArgumentHandler? Next { get; private set; }

    public void AddNext(IFileShowArgumentHandler link)
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

    public abstract FileShowCommandBuilder Handle(IEnumerator enumerator, FileShowCommandBuilder builder);
}