namespace ExpressionParser.Parser.Models;

public static class Structure
{
    public static List<CharacterStructure> Items= new()
    {
        new CharacterStructure ("(", TokenType.StartParentheses, 1),
        new CharacterStructure (")", TokenType.EndParentheses, 1),
        new CharacterStructure ("+=", TokenType.AddAssign,1),        
        new CharacterStructure ("+", TokenType.Add,2),
        new CharacterStructure ("&&", TokenType.AndAlso, 1),        
        new CharacterStructure ("&", TokenType.And, 2),

    };
}

public sealed record CharacterStructure(string Character, TokenType TokenType, int Priority);