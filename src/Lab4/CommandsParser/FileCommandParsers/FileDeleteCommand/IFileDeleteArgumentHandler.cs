using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.FileCommandParsers.FileDeleteCommand;

public interface IFileDeleteArgumentHandler
{
    void AddNext(IFileDeleteArgumentHandler link);
    FileDeleteCommandBuilder Handle(IEnumerator enumerator, FileDeleteCommandBuilder builder);
}