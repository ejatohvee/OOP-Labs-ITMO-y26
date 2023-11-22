using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.TreeCommandParsers.TreeListCommand;

public abstract class TreeListArgumentHandlerBase : ITreeListArgumentHandler
{
    protected ITreeListArgumentHandler? Next { get; private set; }

    public void AddNext(ITreeListArgumentHandler link)
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

    public abstract TreeListCommandBuilder Handle(IEnumerator enumerator, TreeListCommandBuilder builder);
}