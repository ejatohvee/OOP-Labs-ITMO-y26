using System;
using System.Collections.Generic;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Drivers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Filters;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class CorporateSystemTests
{
    [Fact]
    public void MessageStatusUserReceiveMessageMessageMarkedUnread()
    {
        // Arrange
        var messages = new Dictionary<Message, MessageStatus>();
        const int userId = 7878;
        string userName = "Max";
        var user = new UserAddressee(userId, userName, messages);

        const string title = "Sigma male title";
        var topic = new Topic(user, title);

        const string header = "New header";
        const string body = "New body";
        var importanceLevel = new ImportanceLevels(2);
        Message message = new MessageBuilder()
            .WithHeader(header)
            .WithBody(body)
            .WithImportanceLevel(importanceLevel)
            .Build();

        // Act
        topic.TransferMessage(message);
        MessageStatus actualMessageStatus = user.GetMessageStatus(message);

        // Assert
        Assert.Equal(MessageStatus.Unread, actualMessageStatus);
    }

    [Fact]
    public void MessageStatusUserChangeMessageStatusToReadMessageMarkedRead()
    {
        // Arrange
        var messages = new Dictionary<Message, MessageStatus>();
        const int userId = 910910;
        const string userName = "Max";
        var user = new UserAddressee(userId, userName, messages);

        const string title = "Patric Bateman title";
        var topic = new Topic(user, title);

        const string header = "New header";
        const string body = "New body";
        var importanceLevel = new ImportanceLevels(2);
        Message message = new MessageBuilder()
            .WithHeader(header)
            .WithBody(body)
            .WithImportanceLevel(importanceLevel)
            .Build();

        // Act
        topic.TransferMessage(message);
        user.MakeMessageRead(message);
        MessageStatus actualMessageStatus = user.GetMessageStatus(message);

        // Assert
        Assert.Equal(MessageStatus.Read, actualMessageStatus);
    }

    [Fact]
    public void MessageStatusUserChangeReadMessageStatusToReadMessageReturnError()
    {
        // Arrange
        var messages = new Dictionary<Message, MessageStatus>();
        const int userId = 910910;
        const string userName = "Max";
        var user = new UserAddressee(userId, userName, messages);

        const string title = "Patric Bateman male title";
        var topic = new Topic(user, title);

        const string header = "New header";
        const string body = "New body";
        var importanceLevel = new ImportanceLevels(2);
        Message message = new MessageBuilder()
            .WithHeader(header)
            .WithBody(body)
            .WithImportanceLevel(importanceLevel)
            .Build();

        // Act
        topic.TransferMessage(message);
        user.MakeMessageRead(message);

        // Assert
        Assert.Throws<ArgumentException>(() => user.MakeMessageRead(message));
    }

    [Fact]
    public void FilerTestTryToSendMessageWithFilterOnNoSuccess()
    {
        // Arrange
        var mockDisplayDriver = new DisplayDriverMock();
        var display = new Display(mockDisplayDriver);
        Color color = Color.Red;
        var displayAddressee = new DisplayAddresseeAdapter(display, color);

        var messageFilter = new MessageFilter();
        var importanceLevelFilter = new ImportanceLevels(3);
        var displayAddresseeWithFilter = new MessageFilterProxy(displayAddressee, importanceLevelFilter, messageFilter);

        const string title = "Patric Bateman title";
        var topic = new Topic(displayAddresseeWithFilter, title);

        const string header = "New header";
        const string body = "New body";
        var importanceLevelMessage = new ImportanceLevels(2);
        Message message = new MessageBuilder()
            .WithHeader(header)
            .WithBody(body)
            .WithImportanceLevel(importanceLevelMessage)
            .Build();

        // Act
        topic.TransferMessage(message);
        mockDisplayDriver.OutputText();
        string actual = mockDisplayDriver.Text;

        // Assert
        string expected = string.Empty;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LoggerTestTryToLogMessageWithLoggerOnSuccess()
    {
        // Arrange
        var mockDisplayDriver = new DisplayDriverMock();
        var display = new Display(mockDisplayDriver);
        Color color = Color.Red;
        var displayAddressee = new DisplayAddresseeAdapter(display, color);

        var mockConsoleLogger = new ConsoleLoggerMock();
        var displayAddresseeLog = new AddresseeConsoleLogger(displayAddressee, mockConsoleLogger);

        const string title = "Patric Bateman title";
        var topic = new Topic(displayAddressee, title);

        const string header = "New header";
        const string body = "New body";
        var importanceLevelMessage = new ImportanceLevels(2);
        Message message = new MessageBuilder()
            .WithHeader(header)
            .WithBody(body)
            .WithImportanceLevel(importanceLevelMessage)
            .Build();

        // Act
        topic.TransferMessage(message);
        displayAddresseeLog.ReceiveMessage(message);
        string actual = mockDisplayDriver.Text;

        // Assert
        string expected = mockConsoleLogger.OutputString;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MessengerTestSendMessageInMessengerReceiveExpectedValue()
    {
        // Arrange
        var mockMessenger = new MessengerMock();
        var messengerAddressee = new MessengerAddresseeAdapter(mockMessenger);

        const string title = "Patric Bateman title";
        var topic = new Topic(messengerAddressee, title);

        const string header = "New header";
        const string body = "New body";
        var importanceLevelMessage = new ImportanceLevels(2);
        Message message = new MessageBuilder()
            .WithHeader(header)
            .WithBody(body)
            .WithImportanceLevel(importanceLevelMessage)
            .Build();

        // Act
        topic.TransferMessage(message);
        string actual = mockMessenger.OutputString;

        // Assert
        string expected = header + "\n" + body;
        Assert.Equal(expected, actual);
    }
}