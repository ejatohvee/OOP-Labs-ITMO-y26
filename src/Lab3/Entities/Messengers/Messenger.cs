using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public class Messenger : IMessenger
{
    public Messenger(string name, Collection<string> messages)
    {
        Name = name;
        Messages = messages;
    }

    public string Name { get; set; }

    private Collection<string> Messages { get; }

    public void PrintMessage(string message)
    {
        Console.WriteLine("Messenger: \n");
        Console.WriteLine(message, "\n");
    }
}