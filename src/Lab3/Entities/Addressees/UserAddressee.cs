using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public class UserAddressee : IAddressee
{
    public UserAddressee(int id, string name, IDictionary<Message, MessageStatus> messages)
    {
        Id = id;
        Name = name;
        Messages = messages;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    private IDictionary<Message, MessageStatus> Messages { get; }

    public void ReceiveMessage(Message message)
    {
        const MessageStatus messageStatus = MessageStatus.Unread;
        Messages.Add(message, messageStatus);
    }

    public void MakeMessageRead(Message message)
    {
        if (!Messages.ContainsKey(message) || Messages[message] == MessageStatus.Read)
        {
            throw new ArgumentException("Message is already read or doesn't exist.");
        }

        Messages[message] = MessageStatus.Read;
    }

    public MessageStatus GetMessageStatus(Message message)
    {
        return Messages[message];
    }
}