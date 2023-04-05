using System;
using System.Collections.Generic;
using System.Text;

namespace BlueRose.Exceptions
{
    internal class lexerException : Exception
    {
        public lexerException(string msg, int line, int pos) : base($"Lexer Exception in Line {line}, at Position {pos}.\n{msg}.") { }
    }
}
