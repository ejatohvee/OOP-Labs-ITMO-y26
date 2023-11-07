using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class DisplayAddresseeAdapter : IAddressee
{
    private readonly Display _display;

    public DisplayAddresseeAdapter(Display display, Color color)
    {
        _display = display;
        Color = color;
    }

    public Color Color { get; set; }

    public void ReceiveMessage(Message message)
    {
        _display.PrintText(
            message.Header + "\n" + message.Body, Color);
    }
}