using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class MessageBuilder
{
    private ImportanceLevels? _importanceLevel;
    private string? _header;
    private string? _body;

    public MessageBuilder WithImportanceLevel(ImportanceLevels importanceLevel)
    {
        _importanceLevel = importanceLevel;
        return this;
    }

    public MessageBuilder WithHeader(string header)
    {
        _header = header;
        return this;
    }

    public MessageBuilder WithBody(string body)
    {
        _body = body;
        return this;
    }

    public Message Build()
    {
        return new Message(
            _importanceLevel ?? throw new ArgumentNullException(nameof(_importanceLevel)),
            _header ?? throw new ArgumentNullException(nameof(_header)),
            _body ?? throw new ArgumentNullException(nameof(_body)));
    }
}