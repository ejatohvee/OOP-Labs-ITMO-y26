using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileShowCommand;

public interface IFileShowArgumentHandler
{
    void AddNext(IFileShowArgumentHandler link);
    FileShowCommandBuilder Handle(IEnumerator enumerator, FileShowCommandBuilder builder);
}