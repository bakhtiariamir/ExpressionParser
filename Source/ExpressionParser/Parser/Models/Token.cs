namespace ExpressionParser.Parser.Models;

public class Token(string Characters, int Index, int Count, TokenType? OwnTokenType,  int? RelatedTokenTypeIndex);
