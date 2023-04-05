using BlueRose.Parser.AST;
using BlueRose.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;

namespace BlueRose.Parser
{
    internal class Parser
    {
        private List<Token> tList;
        private int idx = -1;
        private Token curTok() => tList[idx];

        public Parser(List<Token> tokens)
        {
            tList = tokens;
            advance();
        }

        public ParserResult Parse()
        {
            var res = expr();
            if (res.HasError)
            {
                throw res.Error;
            }
            else
            {
                if (curTok().Type != TokenTypes.TokenType.T_EOF)
                {
                    throw new Exception($"Syntax Error : expected Operator in Line {curTok().Line}, position {curTok().Pos}.");
                }
            }


            return res;
        }
        private ParserResult factor()
        {
            Token Tok = curTok();
            if (Tok.Type == TokenTypes.TokenType.T_ADD || Tok.Type == TokenTypes.TokenType.T_SUB)
            {
                advance();
                ParserResult FactorRes = factor();
                if (FactorRes.HasError) return FactorRes;
                return new ParserResult(new UnaryOperation(Tok, FactorRes.Node));
            }
            else if (Tok.Type == TokenTypes.TokenType.T_INT || Tok.Type == TokenTypes.TokenType.T_FLOAT)
            {
                advance();
                return new ParserResult(new NumberNode(Tok));
            }
            else if (Tok.Type == TokenTypes.TokenType.T_LPAREN)
            {
                advance();
                ParserResult ExpressIt = expr();
                if (ExpressIt.HasError) return ExpressIt;
                if (curTok().Type == TokenTypes.TokenType.T_RPAREN)
                {
                    advance();
                    return new ParserResult(ExpressIt.Node);
                }
                else
                {
                    throw new Exception($"Syntax Error : expected ')' in Line {curTok().Line}, position {curTok().Pos}.");
                }
            }
            return new ParserResult(new syntaxException($"Expected a Number but found '{Tok.Type}'", Tok.Line, Tok.Pos));
        }
        private ParserResult term()
        {
            return BinaryOp(factor, new List<TokenTypes.TokenType> { TokenTypes.TokenType.T_MUL, TokenTypes.TokenType.T_DIV });
        }
        private ParserResult expr()
        {
            return BinaryOp(term, new List<TokenTypes.TokenType> { TokenTypes.TokenType.T_ADD, TokenTypes.TokenType.T_SUB });
        }
        private ParserResult BinaryOp(Func<ParserResult> Operation, List<TokenTypes.TokenType> Ops)
        {
            ParserResult Left = Operation();
            if (Left.HasError) return Left;
            while ((from x in Ops where curTok().Type == x select x).Any())
            {
                Token opTok = curTok();
                advance();
                ParserResult Right = Operation();
                if (Right.Error != null) return Right;
                Left = new ParserResult(new BinaryOperation(Left.Node, opTok, Right.Node));
            }
            return Left;
        }

        private void advance()
        {
            if (idx < tList.Count) idx++;
        }
        private Token Peek(int offset = 1)
        {
            if (idx + 1 < tList.Count) return tList[idx + 1];
            else return new Token(TokenTypes.TokenType.T_EOF, "", -1, -1);
        }
    }
}
