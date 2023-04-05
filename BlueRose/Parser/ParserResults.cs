using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml.Linq;
using BlueRose.Exceptions;
using BlueRose.Parser.AST;
namespace BlueRose.Parser
{
    internal class ParserResult
    {
        public Node Node { get; set; }
        public syntaxException Error { get; set; }
        public bool HasError { get { return Error != null; } }
        public ParserResult(Node node)
        {
            this.Node = node;
        }
        public ParserResult(syntaxException error)
        {
            this.Error = error;
        }

        public string print()
        {
            return this.Node.print();
        }
    }
}
