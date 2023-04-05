using System;
using System.Collections.Generic;
using System.Text;

namespace BlueRose.Parser
{
    internal class Token
    {
        public TokenTypes.TokenType Type { get; set; } = TokenTypes.TokenType.T_EOF;
        public string Value { get; set; } = string.Empty;

        public int Line { get; set; } = -1;
        public int Pos { get; set; } = -1;

        public Token(TokenTypes.TokenType type, string value, int line, int pos)
        {
            Type = type;
            Value = value;
            Line = line;
            Pos = pos;
        }
        public Token() { }

        public string print()
        {
            return $"{this.Value}";
        }
    }
}
