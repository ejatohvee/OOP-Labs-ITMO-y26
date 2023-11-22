using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileCopyCommand;

public abstract class FileCopyArgumentHandlerBase : IFileCopyArgumentHandler
{
    protected IFileCopyArgumentHandler? Next { get; private set; }

    public void AddNext(IFileCopyArgumentHandler link)
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

    public abstract FileCopyCommandBuilder Handle(IEnumerator enumerator, FileCopyCommandBuilder builder);
}