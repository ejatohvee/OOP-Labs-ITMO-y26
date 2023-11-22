using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;
using Itmo.ObjectOrientedProgramming.Lab4.CommandsParser.DisconnectCommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class TestParser
{
    [Fact]
    public void Disconnect()
    {
        // Arrange
        var disconnectCommandHandler = new DisconnectCommandHandler();
        string test = "disconnect";

        var iterator = new StringRequest(test);
        var localFileSystem = new LocalFileSystem();

        var context = new GlobalContext(localFileSystem);

        // Act
        ICommand? command = disconnectCommandHandler.Handle(iterator);
        ExecutionResult? result = command?.Execute(context);

        // Assert
        Assert.Equal(ExecutionResult.Success, result);
    }
}