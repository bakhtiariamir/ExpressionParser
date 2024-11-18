﻿namespace ExpressionParser.Parser.Models;

public static class TokenState
{
    public static readonly List<RelatedTokenState> RelatedTokens = [
        new RelatedTokenState(TokenType.StartParentheses, "(", TokenType.EndParentheses, ")"),
        new RelatedTokenState(TokenType.StartParentheses, "{", TokenType.EndParentheses, "}"),        
        new RelatedTokenState(TokenType.StartParentheses, "[", TokenType.EndParentheses, "]"),        
    ];
    
    public static readonly List<TokenTypeState> Items = [
        new TokenTypeState(TokenType.StartParentheses, "("),
        new TokenTypeState(TokenType.EndParentheses, ")"),
        new TokenTypeState(TokenType.Add, "+"),
        new TokenTypeState(TokenType.And, "&"),
        new TokenTypeState(TokenType.Divide, "/"),
        new TokenTypeState(TokenType.GreaterThan, ">"),
        new TokenTypeState(TokenType.LessThan, "<"),
        new TokenTypeState(TokenType.Modulo, "%"),
        new TokenTypeState(TokenType.Multiply, "*"),
        new TokenTypeState(TokenType.Negate, "-"),
        new TokenTypeState(TokenType.Power, "^"),
        new TokenTypeState(TokenType.Not, "!"),
        new TokenTypeState(TokenType.Or, "|"),
        new TokenTypeState(TokenType.Parameter, "@"),
        new TokenTypeState(TokenType.Subtract, "-"),
        new TokenTypeState(TokenType.OrElse, "||"),
        new TokenTypeState(TokenType.OrAssign, "|="),
        new TokenTypeState(TokenType.PowerAssign, "^="),
        new TokenTypeState(TokenType.SubtractAssign, "-="),
        new TokenTypeState(TokenType.AndAlso, "&&"),
        new TokenTypeState(TokenType.AndAssign, "&="),        
        new TokenTypeState(TokenType.ArrayLength, "[-]"),
        new TokenTypeState(TokenType.Conditional, "?:"),
        new TokenTypeState(TokenType.DivideAssign, "/="),        
        new TokenTypeState(TokenType.Equal, "=="),
        new TokenTypeState(TokenType.NotEqual, "!="),
        new TokenTypeState(TokenType.LessThanOrEqual, "<="),
        new TokenTypeState(TokenType.ListInit, "={}"),
        new TokenTypeState(TokenType.ModuloAssign, "%="),        
        new TokenTypeState(TokenType.MultiplyAssign, "*="),
        new TokenTypeState(TokenType.UnaryPlus, "(+)"),
        new TokenTypeState(TokenType.New, "new"),
        new TokenTypeState(TokenType.GreaterThanOrEqual, ">="),
        //new TokenTypeState(TokenType.NegateChecked, ""),
        //new TokenTypeState(TokenType.NewArrayBounds, ""),
        //new TokenTypeState(TokenType.MultiplyChecked, ""),
        //new TokenTypeState(TokenType.Quote, ""),
        //new TokenTypeState(TokenType.RightShift, ""),        
        //new TokenTypeState(TokenType.Cot, "\""),        
        //new TokenTypeState(TokenType.Call, ""),
        //new TokenTypeState(TokenType.Constant, "{}"),
        //new TokenTypeState(TokenType.Convert, ""),
        //new TokenTypeState(TokenType.ConvertChecked, ""),
        //new TokenTypeState(TokenType.Invoke, ""),
        //new TokenTypeState(TokenType.Lambda, ""),
        //new TokenTypeState(TokenType.LeftShift, ""),  
        //new TokenTypeState(TokenType.SubtractChecked, "-="),
        //new TokenTypeState(TokenType.TypeAs, ""),
        //new TokenTypeState(TokenType.TypeIs, ""),
        //new TokenTypeState(TokenType.Assign, ""),
        //new TokenTypeState(TokenType.Block, ""),
        //new TokenTypeState(TokenType.Decrement, ""),
        //new TokenTypeState(TokenType.Dynamic, ""),
        //new TokenTypeState(TokenType.Extension, ""),
        //new TokenTypeState(TokenType.Goto, ""),
        //new TokenTypeState(TokenType.Increment, ""),
        //new TokenTypeState(TokenType.Index, ""),
        //new TokenTypeState(TokenType.Label, ""),
        //new TokenTypeState(TokenType.RuntimeVariables,
        //  ""), //A list of run-time variables. For more information, see RuntimeVariablesExpression.
        //new TokenTypeState(TokenType.Loop, ""),
        //new TokenTypeState(TokenType.Switch, ""),
        //new TokenTypeState(TokenType.Throw, ""),
        //new TokenTypeState(TokenType.Try, ""),
        //new TokenTypeState(TokenType.Unbox, ""),
        //new TokenTypeState(TokenType.AddAssign, ""),
        //new TokenTypeState(TokenType.AndAssign, ""),
        //new TokenTypeState(TokenType.DivideAssign, ""),
        //new TokenTypeState(TokenType.LeftShiftAssign, ""),
        //new TokenTypeState(TokenType.ModuloAssign, ""),
        //new TokenTypeState(TokenType.MultiplyAssign, ""),
        //new TokenTypeState(TokenType.OrAssign, ""),
        //new TokenTypeState(TokenType.PowerAssign, ""),
        //new TokenTypeState(TokenType.RightShiftAssign, ""),
        //new TokenTypeState(TokenType.SubtractAssign, ""),
        //new TokenTypeState(TokenType.AddAssignChecked, ""),
        //new TokenTypeState(TokenType.MultiplyAssignChecked, ""),
        //new TokenTypeState(TokenType.SubtractAssignChecked, ""),
        //new TokenTypeState(TokenType.PreIncrementAssign, ""),
        //new TokenTypeState(TokenType.PreDecrementAssign, ""),
        //new TokenTypeState(TokenType.PostIncrementAssign, ""),
        //new TokenTypeState(TokenType.PostDecrementAssign, ""),
        //new TokenTypeState(TokenType.TypeEqual, ""),
        //new TokenTypeState(TokenType.OnesComplement, ""),
        //new TokenTypeState(TokenType.IsTrue, ""),
        //new TokenTypeState(TokenType.IsFalse, "")
    ];

    public static readonly List<TokenPriority> TokenPriorities = [
        new TokenPriority(TokenType.StartParentheses, new CategoryOperands("Postfix", "()"), 1, Associativity.LeftToRight),
        new TokenPriority(TokenType.StartBracket, new CategoryOperands("Postfix","[]"), 2, Associativity.LeftToRight),
        new TokenPriority(TokenType.RightArrow, new CategoryOperands("Postfix", "->"), 3, Associativity.LeftToRight),
        new TokenPriority(TokenType.Dot, new CategoryOperands("Postfix", "."), 4, Associativity.LeftToRight),
        new TokenPriority(TokenType.DoublePlus, new CategoryOperands("Postfix", "++"), 5, Associativity.LeftToRight),
        new TokenPriority(TokenType.DoubleNegative, new CategoryOperands("Postfix", "--"), 6, Associativity.LeftToRight),
        new TokenPriority(TokenType.Add, new CategoryOperands("Unary", "+"), 7, Associativity.RightToLeft),
        new TokenPriority(TokenType.Negate, new CategoryOperands("Unary", "-"), 8, Associativity.RightToLeft),
        //new TokenPriority(TokenType.Opposite, new CategoryOperands("Unary", "!"), 1, Associativity.RightToLeft),
        new TokenPriority(TokenType.Mad, new CategoryOperands("Unary", "~"), 10, Associativity.RightToLeft),
        new TokenPriority(TokenType.Ampersand, new CategoryOperands("Unary", "&"), 11, Associativity.RightToLeft),

        new TokenPriority(TokenType.Multiply, new CategoryOperands("Multiplicative", "*"), 12, Associativity.LeftToRight),
        new TokenPriority(TokenType.Divide, new CategoryOperands("Multiplicative", "/"), 13, Associativity.LeftToRight),
        new TokenPriority(TokenType.Modulo, new CategoryOperands("Multiplicative", "%"), 14, Associativity.LeftToRight),
        //new TokenPriority(TokenType.StartParentheses, new CategoryOperands("Shift", "<<"), 15, Associativity.LeftToRight),
        //new TokenPriority(TokenType.StartParentheses, new CategoryOperands("Shift", ">>"), 16, Associativity.LeftToRight),
        new TokenPriority(TokenType.LessThan, new CategoryOperands("Relational", "<"), 17, Associativity.LeftToRight),
        new TokenPriority(TokenType.LessThanOrEqual, new CategoryOperands("Relational", "<="), 18, Associativity.LeftToRight),
        new TokenPriority(TokenType.GreaterThan, new CategoryOperands("Relational", ">"), 19, Associativity.LeftToRight),
        new TokenPriority(TokenType.GreaterThanOrEqual, new CategoryOperands("Relational", ">="), 20, Associativity.LeftToRight),

        new TokenPriority(TokenType.Add, new CategoryOperands("Additive", "+"), 21, Associativity.LeftToRight),
        new TokenPriority(TokenType.Subtract, new CategoryOperands("Additive", "-"), 22, Associativity.LeftToRight),
        
        new TokenPriority(TokenType.Equality, new CategoryOperands("Equality", "=="), 23, Associativity.LeftToRight),
        new TokenPriority(TokenType.Opposite, new CategoryOperands("Equality", "!="), 24, Associativity.LeftToRight),
        
        new TokenPriority(TokenType.And, new CategoryOperands("Bitwise AND", "&"), 25, Associativity.LeftToRight),
        new TokenPriority(TokenType.Power, new CategoryOperands("Bitwise XOR", "^"), 26, Associativity.LeftToRight),

        new TokenPriority(TokenType.AndAlso, new CategoryOperands("Logical AND", "&&"), 27, Associativity.LeftToRight),
        new TokenPriority(TokenType.OrElse, new CategoryOperands("Logical OR", "||"), 28, Associativity.LeftToRight),
        new TokenPriority(TokenType.Conditional, new CategoryOperands("Conditional", "?:"), 29, Associativity.RightToLeft),
        
        new TokenPriority(TokenType.AddAssign, new CategoryOperands("Assignment", "+="), 30, Associativity.LeftToRight),
        new TokenPriority(TokenType.SubtractAssign, new CategoryOperands("Assignment", "-="), 31, Associativity.LeftToRight),
        new TokenPriority(TokenType.MultiplyAssign, new CategoryOperands("Assignment", "*="), 32, Associativity.LeftToRight),
        new TokenPriority(TokenType.DivideAssign, new CategoryOperands("Assignment", "/="), 33, Associativity.LeftToRight),
        new TokenPriority(TokenType.ModuloAssign, new CategoryOperands("Assignment", "%="), 34, Associativity.LeftToRight),
        //new TokenPriority(TokenType.StartParentheses, new CategoryOperands("Assignment", ">>="), 1, Associativity.LeftToRight),
        //new TokenPriority(TokenType.StartParentheses, new CategoryOperands("Assignment", "<<="), 1, Associativity.LeftToRight),
        //new TokenPriority(TokenType.StartParentheses, new CategoryOperands("Assignment", "&="), 1, Associativity.LeftToRight),
    ];
}