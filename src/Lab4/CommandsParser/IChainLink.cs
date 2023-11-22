using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;

public interface IChainLink
{
    string Name { get; }
    void AddNext(IChainLink link);

    ICommand? Handle(IEnumerator request);
}