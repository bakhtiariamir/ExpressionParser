using ExpressionParser.Parser.Models;

namespace ExpressionParser.Extensions;

public static class TokenExtensions
{
    public static TokenType GetTokenType(string character) =>
        TokenState.Items.FirstOrDefault(item => item.Character.ToLower() == character)!.TokenType;

    public static TokenType? RelatedTokenType(string character)
    {
        if (character.ToLower() == ")")
            return TokenState.Items.FirstOrDefault(item => item.Character.ToLower() == "(")!.TokenType;

        return default;
    }
}