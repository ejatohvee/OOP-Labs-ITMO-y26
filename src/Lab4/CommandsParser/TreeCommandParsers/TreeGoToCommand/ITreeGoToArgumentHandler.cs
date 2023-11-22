using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.TreeCommandParsers.TreeGoToCommand;

public interface ITreeGoToArgumentHandler
{
    void AddNext(ITreeGoToArgumentHandler link);
    TreeGoToCommandBuilder Handle(IEnumerator enumerator, TreeGoToCommandBuilder builder);
}