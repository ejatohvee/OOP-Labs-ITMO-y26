using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeListRealization;

public class LocalDirectoryTraversal : ITraversal
{
    public IElement Traverse(string path, int depth)
    {
        var directoryInfo = new DirectoryInfo(path);
        var directory = new Directory(directoryInfo.Name);

        foreach (FileInfo fileInfo in directoryInfo.GetFiles())
        {
            directory.AddItem(new File(fileInfo.Name));
        }

        foreach (DirectoryInfo tmpDirectoryInfo in directoryInfo.GetDirectories())
        {
            directory.AddItem(depth == 0
                ? new Directory(tmpDirectoryInfo.Name)
                : Traverse(tmpDirectoryInfo.FullName, depth - 1));
        }

        return directory;
    }
}