using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public interface IDisplay
{
    public void PrintText(string message, Color color);
}