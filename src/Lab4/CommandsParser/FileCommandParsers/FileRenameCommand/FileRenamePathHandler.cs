using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileRenameCommand;

public class FileRenamePathHandler : FileRenameArgumentHandlerBase
{
    public override FileRenameCommandBuilder Handle(IEnumerator enumerator, FileRenameCommandBuilder builder)
    {
        builder.WithSourcePath((string)enumerator.Current);
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