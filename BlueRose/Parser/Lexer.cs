using System;
using System.Collections.Generic;
using System.Text;

namespace BlueRose.Parser
{
    internal class Lexer
    {
        private string source = string.Empty;
        private int pos = 0;

        #region JustForCount
        private int curLine = 1;
        private int curLinePos = 1;
        #endregion
        public Lexer(string src)
        {
            source = src;
        }

        private void advance()
        {

            pos++;
            if (pos < source.Length)
            {
                if (source[pos] == '\n')
                {
                    curLine++;
                    curLinePos = 1;
                }
                else curLinePos++;
            }
        }

        public List<Token> getTokens()
        {
            List<Token> tokens = new List<Token>();
            char temp = '\0';
            while (pos < source.Length)
            {
                if (char.IsWhiteSpace(source[pos]))
                    advance();
                else if (char.IsDigit(source[pos]))
                {
                    tokens.Add(makeNumber());
                }
                else if (source[pos] == '+')
                {
                    tokens.Add(new Token(TokenTypes.TokenType.T_ADD, "+", curLine, curLinePos));
                    advance();
                }
                else if (source[pos] == '-')
                {
                    tokens.Add(new Token(TokenTypes.TokenType.T_SUB, "-", curLine, curLinePos));
                    advance();
                }
                else if (source[pos] == '*')
                {
                    tokens.Add(new Token(TokenTypes.TokenType.T_MUL, "*", curLine, curLinePos));
                    advance();
                }
                else if (source[pos] == '/')
                {
                    tokens.Add(new Token(TokenTypes.TokenType.T_DIV, "/", curLine, curLinePos));
                    advance();
                }
                else if (source[pos] == '(')
                {
                    tokens.Add(new Token(TokenTypes.TokenType.T_LPAREN, "(", curLine, curLinePos));
                    advance();
                }
                else if (source[pos] == ')')
                {
                    tokens.Add(new Token(TokenTypes.TokenType.T_RPAREN, ")", curLine, curLinePos));
                    advance();
                }
                else
                {
                    temp = source[pos];
                    advance();
                    throw new Exceptions.lexerException($"Unexpected Token '{temp}'.", curLine, curLinePos);
                }
            }
            tokens.Add(new Token(TokenTypes.TokenType.T_EOF, "\0", curLine, ++curLinePos));
            return tokens;
        }

        private Token makeNumber()
        {
            string temp = string.Empty;
            int dotCount = 0;
            while (pos < source.Length && (char.IsDigit(source[pos]) || source[pos] == '.'))
            {
                if (source[pos] == '.')
                {
                    if (dotCount == 1) break;
                    dotCount++;
                    temp += source[pos];
                }
                else
                {
                    temp += source[pos];
                }

                advance();
            }
            return (dotCount == 1 ? new Token(TokenTypes.TokenType.T_FLOAT, temp, curLine, curLinePos) :
                                    new Token(TokenTypes.TokenType.T_INT, temp, curLine, curLinePos));
        }
    }
}
