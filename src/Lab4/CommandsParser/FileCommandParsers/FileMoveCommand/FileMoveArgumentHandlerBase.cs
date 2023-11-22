using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileMoveCommand;

public abstract class FileMoveArgumentHandlerBase : IFileMoveArgumentHandler
{
    protected IFileMoveArgumentHandler? Next { get; private set; }

    public void AddNext(IFileMoveArgumentHandler link)
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

    public abstract FileMoveCommandBuilder Handle(IEnumerator enumerator, FileMoveCommandBuilder builder);
}