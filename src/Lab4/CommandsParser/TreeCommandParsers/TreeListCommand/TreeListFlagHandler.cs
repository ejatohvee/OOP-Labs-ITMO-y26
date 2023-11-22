using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.TreeCommandParsers.TreeListCommand;

public class TreeListFlagHandler : TreeListArgumentHandlerBase
{
    private const string FlagName = "-d";

    public override TreeListCommandBuilder Handle(IEnumerator enumerator, TreeListCommandBuilder builder)
    {
        if ((string)enumerator.Current == FlagName && enumerator.MoveNext())
        {
            int depth = (int)enumerator.Current;
            builder.WithSelectionDepth(depth);
        }
        else
        {
            return builder;
        }

        if (enumerator.MoveNext() && Next is not null)
        {
            return Next.Handle(enumerator, builder);
        }
        else
        {
            return builder;
        }
    }
}