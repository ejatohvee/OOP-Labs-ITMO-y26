using System.Collections;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;

public class StringRequest : IEnumerator
{
    private IList<string> _commands;
    private int _currentIndex;

    public StringRequest(string commands)
    {
        _commands = commands.Split(" ");
        _currentIndex = 0;
    }

    public object Current => _commands[_currentIndex];

    public bool MoveNext()
    {
        _currentIndex++;
        return _currentIndex < _commands.Count;
    }

    public void Reset()
    {
        _currentIndex = 0;
    }
}