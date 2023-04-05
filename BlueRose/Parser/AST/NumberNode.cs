using System;
using System.Collections.Generic;
using System.Text;

namespace BlueRose.Parser.AST
{
    internal class NumberNode : Node
    {
        public Token Number { get; set; }
        public NumberNode(Token number)
        {
            Number = number;
        }

        public override string print()
        {
            return $"{Number.print()}";
        }

    }
}
