using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.ConnectCommandParser;

public interface IConnectArgumentHandler
{
    void AddNext(IConnectArgumentHandler link);
    ConnectCommandBuilder Handle(IEnumerator enumerator, ConnectCommandBuilder builder);
}