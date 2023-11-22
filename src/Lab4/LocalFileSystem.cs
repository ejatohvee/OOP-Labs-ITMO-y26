using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.TreeListRealization;
using Directory = System.IO.Directory;
using File = System.IO.File;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class LocalFileSystem : IFileSystem
{
    private ITraversal _traversal = new LocalDirectoryTraversal();
    private string _currentDirectory = Directory.GetCurrentDirectory();

    public FileSystemOperationResult TreeList(int depth)
    {
        if (depth < 0)
        {
            return FileSystemOperationResult.Fail;
        }

        IElement root = _traversal.Traverse(_currentDirectory, depth);
        var treeVisitor = new TreeVisitor(depth);
        root.Accept(treeVisitor);
        return FileSystemOperationResult.Success;
    }

    public FileSystemOperationResult TreeGoTo(string path)
    {
        if (!Directory.Exists(path))
        {
            Console.WriteLine("Directory not found: " + path);
            return FileSystemOperationResult.Fail;
        }

        Environment.CurrentDirectory = path;
        Console.WriteLine("Current directory changed to: " + path);
        return FileSystemOperationResult.Success;
    }

    public FileSystemOperationResult Connect(string address, ConnectonMode mode)
    {
        if (mode == ConnectonMode.Local)
        {
            _currentDirectory = address;
            Console.WriteLine($"Connected to local filesystem. Current directory: {_currentDirectory}");
            return FileSystemOperationResult.Success;
        }

        Console.WriteLine($"Unsupported filesystem mode: {mode}");
        return FileSystemOperationResult.Fail;
    }

    public FileSystemOperationResult Disconnect()
    {
        Console.WriteLine("Disconnected from the filesystem.");
        return FileSystemOperationResult.Success;
    }

    public FileSystemOperationResult MoveFile(string sourcePath, string destinationPath)
    {
        try
        {
            File.Move(sourcePath, destinationPath);
            return FileSystemOperationResult.Success;
        }
        catch (InvalidOperationException)
        {
            return FileSystemOperationResult.Fail;
        }
    }

    public FileSystemOperationResult CopyFile(string sourcePath, string destinationPath)
    {
        try
        {
            File.Copy(sourcePath, destinationPath);
            return FileSystemOperationResult.Success;
        }
        catch (InvalidOperationException)
        {
            return FileSystemOperationResult.Fail;
        }
    }

    public FileSystemOperationResult DeleteFile(string filePath)
    {
        try
        {
            File.Delete(filePath);
            return FileSystemOperationResult.Success;
        }
        catch (InvalidOperationException)
        {
            return FileSystemOperationResult.Fail;
        }
    }

    public FileSystemOperationResult RenameFile(string oldFilePath, string newFileName)
    {
        try
        {
            string? directory = Path.GetDirectoryName(oldFilePath);
            if (directory == null) return FileSystemOperationResult.Fail;
            string newFilePath = Path.Combine(directory, newFileName);

            File.Move(oldFilePath, newFilePath);
            return FileSystemOperationResult.Success;
        }
        catch (InvalidOperationException)
        {
            return FileSystemOperationResult.Fail;
        }
    }

    public void CatalogueShow(string directoryPath)
    {
        try
        {
            string[] directories = Directory.GetDirectories(directoryPath);
            string[] files = Directory.GetFiles(directoryPath);

            Console.WriteLine($"Directories in '{directoryPath}':");
            foreach (string dir in directories)
            {
                Console.WriteLine(Path.GetFileName(dir));
            }

            Console.WriteLine($"\nFiles in '{directoryPath}':");
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }
        catch (IOException exception)
        {
            Console.WriteLine($"Error showing catalog: {exception.Message}");
        }
    }

    public void FileShow(string filePath, FileShowMode showMode)
    {
        if (showMode == FileShowMode.Console)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    Console.WriteLine($"Content of file '{filePath}':\n{content}");
                }
                else
                {
                    Console.WriteLine($"File '{filePath}' does not exist.");
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine($"Error showing file: {exception.Message}");
            }
        }
    }
}