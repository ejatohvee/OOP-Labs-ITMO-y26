using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileDeleteCommand;

public abstract class FileDeleteArgumentHandlerBase : IFileDeleteArgumentHandler
{
    protected IFileDeleteArgumentHandler? Next { get; private set; }

    public void AddNext(IFileDeleteArgumentHandler link)
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

    public abstract FileDeleteCommandBuilder Handle(IEnumerator enumerator, FileDeleteCommandBuilder builder);
}