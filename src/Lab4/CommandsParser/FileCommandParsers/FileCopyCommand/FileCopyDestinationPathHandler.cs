using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileCopyCommand;

public class FileCopyDestinationPathHandler : FileCopyArgumentHandlerBase
{
    public override FileCopyCommandBuilder Handle(IEnumerator enumerator, FileCopyCommandBuilder builder)
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