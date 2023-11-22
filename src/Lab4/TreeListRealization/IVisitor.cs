namespace Itmo.ObjectOrientedProgramming.Lab4.TreeListRealization;

public interface IVisitor
{
    void VisitFile(File file);
    void VisitDirectory(Directory directory);
}