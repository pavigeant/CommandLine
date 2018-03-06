using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CommandLine
{
    public class ArgumentEnumerator : IEnumerator<string>
    {
        private int _currentIndex;
        private string[] _arguments;

        public ArgumentEnumerator(string[] args)
        {
            _currentIndex = -1;
            _arguments = args;
        }

        public string Current
        {
            get
            {
                if (_currentIndex < 0 || _currentIndex >= _arguments.Length)
                    throw new InvalidOperationException("Cannot get current because MoveNext hasn't been call.");

                return _arguments[_currentIndex];
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public string Peek()
        {
            if (_currentIndex + 1 < _arguments.Length)
                return _arguments[_currentIndex + 1];

            return null;
        }

        public bool MoveNext()
        {
            if (_currentIndex++ + 1 < _arguments.Length)
                return true;

            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }
    }
}