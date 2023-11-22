using System.Collections;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.TreeCommandParsers;

public class TreeCommandHandler : BaseHandler
{
    private const string FileCommandName = "tree";

    public TreeCommandHandler()
        : base(FileCommandName)
    { }

    public override ICommand? Handle(IEnumerator request)
    {
        if (request.MoveNext() && Successors.Any(x => x.Name == (string)request.Current))
        {
            IChainLink nextRequest = Successors.First(x => x.Name == (string)request.Current);
            nextRequest.Handle(request);
        }

        return null;
    }
}