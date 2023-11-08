using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Drivers;

public class DisplayDriver : IDriver
{
    public DisplayDriver(Color color, string text)
    {
        Color = color;
        Text = text;
    }

    public Color Color { get; set; }
    public string Text { get; set; }

    public void OutputText()
    {
        Console.WriteLine(Text);
    }

    public void ClearOutput()
    {
        Console.Clear();
    }
}