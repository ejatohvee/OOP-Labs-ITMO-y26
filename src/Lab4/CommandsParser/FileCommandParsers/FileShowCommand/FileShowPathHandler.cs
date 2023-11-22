using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileShowCommand;

public class FileShowPathHandler : FileShowArgumentHandlerBase
{
    public override FileShowCommandBuilder Handle(IEnumerator enumerator, FileShowCommandBuilder builder)
    {
        builder.WithFilePath((string)enumerator.Current);
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