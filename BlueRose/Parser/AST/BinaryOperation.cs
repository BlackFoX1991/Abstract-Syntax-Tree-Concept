using System;
using System.Collections.Generic;
using System.Text;

namespace BlueRose.Parser.AST
{
    internal class BinaryOperation : Node
    {
        public Node Left { get; set; }
        public Token tOperator { get; set; }
        public Node Right { get; set; }

        public BinaryOperation(Node left, Token toperator, Node right)
        {
            Left = left;
            tOperator = toperator;
            Right = right;
        }

        public override string print()
        {
            return $"({this.Left.print()} {this.tOperator.print()} {this.Right.print()})";
        }
    }
}
