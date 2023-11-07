using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class Display : IDisplay
{
    private readonly IDriver _displayDriver;

    public Display(IDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void PrintText(string message, Color color)
    {
        _displayDriver.ClearOutput();
        _displayDriver.Text = message;
        _displayDriver.Color = color;
        _displayDriver.OutputText();
    }
}