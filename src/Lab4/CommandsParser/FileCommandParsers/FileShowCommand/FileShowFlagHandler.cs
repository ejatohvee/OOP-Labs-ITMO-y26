using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileShowCommand;

public class FileShowFlagHandler : FileShowArgumentHandlerBase
{
    private const string FlagName = "-m";

    public override FileShowCommandBuilder Handle(IEnumerator enumerator, FileShowCommandBuilder builder)
    {
        if ((string)enumerator.Current == FlagName && enumerator.MoveNext())
        {
            switch ((string)enumerator.Current)
            {
                case "console":
                    builder.WithShowMode(FileShowMode.Console);
                    break;
                case "display":
                    builder.WithShowMode(FileShowMode.Display);
                    break;
                default:
                    builder.WithShowMode(FileShowMode.Console);
                    break;
            }
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