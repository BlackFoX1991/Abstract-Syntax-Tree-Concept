# BlueRose

This Project is just an Example how to tokenize, parse and create a AST out of an Expression. This Project just shows how to create a abstract Syntax Tree from a Math-Expression. ~~without any evaluation Process which will be added in later Versions to demonstrate how to visit each Node Type, simply interpret the input.~~

Since this is just a Fun-Project it will be updated if i have time.

### Grammer ( EBNF ) :
expression = term  { ("+" | "-") term} .
term       = factor  { ("*"|"/") factor} .
factor     = constant | variable | "("  expression  ")" .

As we can clearly see, Expression equal a Term can followed by Plus or Minus Operator and other Term.
Term equals Factor which can followed by Multiply or divide and another Factor.
Factor equals a Value or another Expression. 

This is how our Parser works, it will loop trough all the Tokens and loop trough the the loop Expression -> Term -> Factor and again Expression until it reached the End of Tokens. Number, Unary and Binary Operation will added to our abstract Syntax Tree.


## Update Log

-> Added a small Interpreter to evaluate the Ast created from a Math-Expression. Currently Supports Plus, Subtract, Divide, Multiply with Numbers and Unary Numbers and also Parenthesis.
