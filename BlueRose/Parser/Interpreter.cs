using BlueRose.Parser.AST;
using System;
using System.Collections.Generic;
using System.Text;
using BlueRose.Parser.Values;
using System.Globalization;

namespace BlueRose.Parser
{
    internal class Interpreter
    {
        public Interpreter()
        {

        }

        public Numbers visit(Node node)
        {
            if (node.GetType() == typeof(NumberNode))
            {
                return VisitNumberNode((NumberNode)node);
            }
            else if (node.GetType() == typeof(BinaryOperation))
            {
                return VisitBinaryNode((BinaryOperation)node);
            }
            else if (node.GetType() == typeof(UnaryOperation))
            {
                return VisitUnaryNode((UnaryOperation)node);
            }
            else
            {
                throw new Exception("");
            }
        }

        private Numbers VisitUnaryNode(UnaryOperation node)
        {
            Numbers number = (Numbers)visit(node.Operand);
            if (node.OP.Type == TokenTypes.TokenType.T_SUB)
            {
                number.SetPosition(node.start_pos, node.end_pos);
                return number.MulOperation(new Numbers(-1));
            }
            else throw new Exception("Invalid Unary Operation.");

        }

        private Numbers VisitNumberNode(NumberNode node)
        {
            Numbers nm = new Numbers(Convert.ToDouble(node.Number.Value, CultureInfo.InvariantCulture));
            nm.SetPosition(node.start_pos, node.end_pos);
            return nm;
        }
        private Numbers VisitBinaryNode(BinaryOperation node)
        {
            Numbers Left = visit(node.Left);
            Numbers Right = visit(node.Right);
            Numbers result = null!;

            if (node.tOperator.Type == TokenTypes.TokenType.T_ADD) result = Left.AddOperation(Right);
            else if (node.tOperator.Type == TokenTypes.TokenType.T_SUB) result = Left.SubOperation(Right);
            else if (node.tOperator.Type == TokenTypes.TokenType.T_DIV) result = Left.DivOperation(Right);
            else if (node.tOperator.Type == TokenTypes.TokenType.T_MUL) result = Left.MulOperation(Right);
            else
            {
                throw new Exception("Invalid Operation.");
            }
            result.SetPosition(node.start_pos, node.end_pos);
            return result;
        }
    }
}
