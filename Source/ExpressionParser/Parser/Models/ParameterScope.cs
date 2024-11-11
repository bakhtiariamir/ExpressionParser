namespace ExpressionParser.Parser.Models;

public sealed record ParameterScope(string Name, List<Token> Tokens, string Phrase);