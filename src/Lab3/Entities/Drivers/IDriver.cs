using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public interface IDriver
{
    public Color Color { get; set; }
    public string Text { get; set; }
    public void ClearOutput();
    public void OutputText();
}