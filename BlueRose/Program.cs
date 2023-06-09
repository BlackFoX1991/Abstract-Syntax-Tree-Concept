﻿using BlueRose.Parser;
using BlueRose.Parser.AST;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using BlueRose.Parser.Values;
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
                        /*Console.Write(ASTS.print());
                        Console.WriteLine();*/
                        Interpreter IP = new Interpreter();
                        Console.WriteLine(IP.visit(ASTS.Node).print());
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
