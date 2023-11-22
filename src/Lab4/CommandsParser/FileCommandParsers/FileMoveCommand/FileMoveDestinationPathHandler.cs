using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileMoveCommand;

public class FileMoveDestinationPathHandler : FileMoveArgumentHandlerBase
{
    public override FileMoveCommandBuilder Handle(IEnumerator enumerator, FileMoveCommandBuilder builder)
    {
        builder.WithDestinationPath((string)enumerator.Current);
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