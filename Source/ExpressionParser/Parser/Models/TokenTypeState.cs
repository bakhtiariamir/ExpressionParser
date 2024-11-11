namespace ExpressionParser.Parser.Models;

public sealed record TokenTypeState(TokenType TokenType, string Character);

public sealed record RelatedTokenState(TokenType TokenType, string Character, TokenType RelatedTokenType, string RelatedCharacter);