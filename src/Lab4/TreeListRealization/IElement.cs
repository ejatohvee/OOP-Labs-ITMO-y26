namespace Itmo.ObjectOrientedProgramming.Lab4.TreeListRealization;

public interface IElement
{
    string Name { get; }
    void Accept(IVisitor visitor);
}