using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileDeleteCommand;

public class FileDeletePathHandler : FileDeleteArgumentHandlerBase
{
    public override FileDeleteCommandBuilder Handle(IEnumerator enumerator, FileDeleteCommandBuilder builder)
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