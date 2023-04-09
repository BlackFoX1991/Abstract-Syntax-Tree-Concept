using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlueRose.Parser.AST
{
    internal class Node
    {
        public int start_pos { get; set; } = 0;
        public int end_pos { get; set; } = 0;
        virtual public string print() { return ""; }
    }
}
