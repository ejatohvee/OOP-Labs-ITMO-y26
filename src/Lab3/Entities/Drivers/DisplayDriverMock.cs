using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Drivers;

public class DisplayDriverMock : IDriver
{
    public Color Color { get; set; } = Color.Empty;
    public string Text { get; set; } = string.Empty;
    public string OutputString { get; private set; } = string.Empty;

    public void ClearOutput()
    {
        OutputString = string.Empty;
    }

    public void OutputText()
    {
        OutputString = Text;
    }
}