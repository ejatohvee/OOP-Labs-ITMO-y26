using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileMoveCommand;

public interface IFileMoveArgumentHandler
{
    void AddNext(IFileMoveArgumentHandler link);
    FileMoveCommandBuilder Handle(IEnumerator enumerator, FileMoveCommandBuilder builder);
}