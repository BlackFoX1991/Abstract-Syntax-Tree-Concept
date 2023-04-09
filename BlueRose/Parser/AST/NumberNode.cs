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
            this.start_pos = number.Pos;
            this.end_pos = number.Pos;
        }

        public override string print()
        {
            return $"{Number.print()}";
        }

    }
}
