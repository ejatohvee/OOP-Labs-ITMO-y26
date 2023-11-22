using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeListRealization;

public class Directory : IElement
{
    public Directory(string name)
    {
        Name = name;
        Children = new List<IElement>();
    }

    public IList<IElement> Children { get; private set; }

    public string Name { get; }

    public void AddItem(IElement item)
    {
        Children.Add(item);
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitDirectory(this);

        foreach (IElement child in Children)
        {
            child.Accept(visitor);
        }
    }
}