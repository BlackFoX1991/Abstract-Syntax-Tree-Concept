using System;
using System.Collections.Generic;
using System.Text;

namespace BlueRose.Parser.AST
{
    internal class UnaryOperation : Node
    {

        public Token OP { get; set; }
        public Node Operand { get; set; }

        public UnaryOperation(Token oP, Node operand)
        {
            OP = oP;
            Operand = operand;
        }

        public override string print()
        {
            return $"({OP.Value}{Operand.print()})";
        }
    }
}
