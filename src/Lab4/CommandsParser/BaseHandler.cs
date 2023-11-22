using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;

public abstract class BaseHandler : IChainLink
{
    protected BaseHandler(string name)
    {
        Name = name;
        Successors = new Collection<IChainLink>();
    }

    public string Name { get; }
    protected IList<IChainLink> Successors { get; }

    public void AddNext(IChainLink link)
    {
        Successors.Add(link);
    }

    public abstract ICommand? Handle(IEnumerator request);
}