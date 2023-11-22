using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.ConnectCommandParser;

public class ConnectFlagHandler : ConnectArgumentHandlerBase
{
    private const string FlagName = "-m";

    public override ConnectCommandBuilder Handle(IEnumerator enumerator, ConnectCommandBuilder builder)
    {
        if ((string)enumerator.Current == FlagName && enumerator.MoveNext())
        {
            switch ((string)enumerator.Current)
            {
                case "Local":
                    builder.WithMode(ConnectonMode.Local);
                    break;
                default:
                    builder.WithMode(ConnectonMode.Local);
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