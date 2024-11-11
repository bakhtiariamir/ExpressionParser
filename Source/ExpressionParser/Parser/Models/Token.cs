namespace ExpressionParser.Parser.Models;

public sealed record Token(string Characters, int Index, TokenType? OwnTokenType,  int? RelatedTokenTypeIndex);
