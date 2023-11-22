namespace Itmo.ObjectOrientedProgramming.Lab4.TreeListRealization;

public interface ITraversal
{
    IElement Traverse(string path, int depth);
}