using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.ConnectCommandParser;

public abstract class ConnectArgumentHandlerBase : IConnectArgumentHandler
{
    protected IConnectArgumentHandler? Next { get; private set; }

    public void AddNext(IConnectArgumentHandler link)
    {
        if (Next is null)
        {
            Next = link;
        }
        else
        {
            Next.AddNext(link);
        }
    }

    public abstract ConnectCommandBuilder Handle(IEnumerator enumerator, ConnectCommandBuilder builder);
}