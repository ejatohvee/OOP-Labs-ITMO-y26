namespace Itmo.ObjectOrientedProgramming.Lab4.TreeListRealization;

public class File : IElement
{
    public File(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitFile(this);
    }
}