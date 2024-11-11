namespace ExpressionParser.Parser.Models;

public sealed record TokenPriority(TokenType Token, CategoryOperands CategoryOperands, int Priority, Associativity Associativity);