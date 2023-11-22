using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileRenameCommand;

public interface IFileRenameArgumentHandler
{
    void AddNext(IFileRenameArgumentHandler link);
    FileRenameCommandBuilder Handle(IEnumerator enumerator, FileRenameCommandBuilder builder);
}