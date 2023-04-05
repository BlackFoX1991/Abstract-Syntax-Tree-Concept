using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BlueRose.Exceptions
{
    internal class syntaxException : Exception
    {
        public syntaxException(string msg, int line, int pos) : base($"Syntax Error in line {line}, at Position {pos}.\n{msg}.") { }
    }
}
