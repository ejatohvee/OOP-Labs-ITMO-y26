using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.TreeCommandParsers.TreeGoToCommand;

public class TreeGoToPathHandler : TreeGoToArgumentHandlerBase
{
    public override TreeGoToCommandBuilder Handle(IEnumerator enumerator, TreeGoToCommandBuilder builder)
    {
        builder.WithPath((string)enumerator.Current);
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