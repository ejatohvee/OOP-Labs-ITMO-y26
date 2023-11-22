using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileCopyCommand;

public interface IFileCopyArgumentHandler
{
    void AddNext(IFileCopyArgumentHandler link);
    FileCopyCommandBuilder Handle(IEnumerator enumerator, FileCopyCommandBuilder builder);
}