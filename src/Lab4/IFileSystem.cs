using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface IFileSystem
{
    void CatalogueShow(string directoryPath);
    void FileShow(string filePath, FileShowMode showMode);
    FileSystemOperationResult CopyFile(string sourcePath, string destinationPath);
    FileSystemOperationResult DeleteFile(string filePath);
    FileSystemOperationResult RenameFile(string oldFilePath, string newFileName);
    FileSystemOperationResult MoveFile(string sourcePath, string destinationPath);
    FileSystemOperationResult Connect(string address, ConnectonMode mode);
    FileSystemOperationResult Disconnect();
    FileSystemOperationResult TreeGoTo(string path);
    FileSystemOperationResult TreeList(int depth);
}