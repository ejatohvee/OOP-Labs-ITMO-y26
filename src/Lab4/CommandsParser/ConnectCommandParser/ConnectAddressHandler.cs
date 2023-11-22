using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.ConnectCommandParser;

public class ConnectAddressHandler : ConnectArgumentHandlerBase
{
    public override ConnectCommandBuilder Handle(IEnumerator enumerator, ConnectCommandBuilder builder)
    {
        builder.WithAddress((string)enumerator.Current);
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