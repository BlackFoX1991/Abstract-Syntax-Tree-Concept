using System;
using System.Collections.Generic;
using System.Text;

namespace BlueRose.Parser
{
    static internal class TokenTypes
    {
        public enum TokenType
        {
            T_EOF,
            T_INT,
            T_FLOAT,
            T_ADD,
            T_SUB,
            T_MUL,
            T_DIV,
            T_LPAREN,
            T_RPAREN
        }
    }
}
