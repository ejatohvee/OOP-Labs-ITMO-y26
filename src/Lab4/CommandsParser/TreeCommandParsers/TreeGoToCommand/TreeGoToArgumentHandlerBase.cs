using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.TreeCommandParsers.TreeGoToCommand;

public abstract class TreeGoToArgumentHandlerBase : ITreeGoToArgumentHandler
{
    protected ITreeGoToArgumentHandler? Next { get; private set; }

    public void AddNext(ITreeGoToArgumentHandler link)
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

    public abstract TreeGoToCommandBuilder Handle(IEnumerator enumerator, TreeGoToCommandBuilder builder);
}