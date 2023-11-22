using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.TreeCommandParsers.TreeListCommand;

public interface ITreeListArgumentHandler
{
    void AddNext(ITreeListArgumentHandler link);
    TreeListCommandBuilder Handle(IEnumerator enumerator, TreeListCommandBuilder builder);
}