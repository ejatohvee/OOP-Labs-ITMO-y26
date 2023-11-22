using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.DisconnectCommandParser;

public class DisconnectCommandHandler : BaseHandler
{
    private const string FileCopyCommandName = "disconnect";

    public DisconnectCommandHandler()
        : base(FileCopyCommandName)
    {
    }

    public override ICommand? Handle(IEnumerator request)
    {
        return new DisconnectCommand();
    }
}