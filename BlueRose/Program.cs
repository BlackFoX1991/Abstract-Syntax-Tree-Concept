using BlueRose.Parser;
using BlueRose.Parser.AST;
using System;
using System.Collections.Generic;

namespace BlueRose
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    string expressIt = Console.ReadLine();
                    if (expressIt == "exit") break;
                    Lexer nlex = new Lexer(expressIt);
                    List<Token> tokens = nlex.getTokens();
                    //foreach (Token t in tokens) Console.Write(t.print());

                    try
                    {
                        Parser.Parser PRS = new Parser.Parser(tokens);
                        ParserResult ASTS = PRS.Parse();
                        if (ASTS.Error != null) { throw ASTS.Error; }
                        Console.Write(ASTS.print());
                        Console.WriteLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
