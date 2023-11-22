using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeListRealization;

public class TreeVisitor : IVisitor
{
    private int _depth;

    public TreeVisitor(int depth)
    {
        this._depth = depth;
    }

    public void VisitFile(File file)
    {
        PrintItem(file);
    }

    public void VisitDirectory(Directory directory)
    {
        PrintItem(directory);

        if (_depth > 0)
        {
            foreach (IElement child in directory.Children)
            {
                child.Accept(new TreeVisitor(_depth - 1));
            }
        }
    }

    private void PrintItem(IElement item)
    {
        Console.WriteLine(new string('-', _depth * 2) + item.Name);
    }
}