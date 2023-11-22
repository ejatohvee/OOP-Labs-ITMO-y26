using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class Message : IEquatable<Message>
{
    public Message(ImportanceLevels importanceLevel, string header, string body)
    {
        ImportanceLevel = importanceLevel;
        Header = header;
        Body = body;
    }

    public string Header { get; init; }
    public string Body { get; init; }
    public ImportanceLevels ImportanceLevel { get; init; }

    public void Render()
    {
        Console.WriteLine(Header);
        Console.WriteLine("\n");
        Console.WriteLine(Body);
        Console.WriteLine("\n");
    }

    public bool Equals(Message? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Header == other.Header;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Message);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Header, Body, ImportanceLevel);
    }
}