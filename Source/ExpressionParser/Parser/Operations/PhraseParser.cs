using System.Collections;
using ExpressionParser.Parser.Models;

namespace ExpressionParser.Parser.Operations;

public class PhraseParser(Phrase phrase)
{
    private readonly Phrase _phrase = phrase;

    public List<Token> Tokenize()
    {
        var startParenthesesStack = new Stack<int>(); 
        var tokenize = new List<Token>();
        var length = _phrase.Expression.Length;
        for (int i = 0; i < length; i++)
        {
            foreach (var item in Structure.Items)
            {
                var countOfCharacter = item.Character.Length;
                if (item.Character.ToLower() == GetToken(_phrase.Expression, i, countOfCharacter).ToLower())
                {
                    var diffIndex = countOfCharacter - 1;
                    i = i + diffIndex;
                    var relatedTokenTypeIndex = 0;
                    if (item.Character is ")")
                    {
                        relatedTokenTypeIndex = startParenthesesStack.Pop();
                        tokenize.Add(new Token(item.Character, i,0, GetTokenType(item.Character), relatedTokenTypeIndex));                        
                    }
                    else if (item.Character is "(")
                    {
                        tokenize.Add(new Token(item.Character, i, startParenthesesStack.Count+1, GetTokenType(item.Character), relatedTokenTypeIndex));
                    }
                    else
                    {
                        tokenize.Add(new Token(item.Character, i,  0,GetTokenType(item.Character), relatedTokenTypeIndex));
                    }

                    
                }
            } 
        }
        return tokenize;
    }

    public TokenType? GetTokenType(string character) => TokenState.Items.FirstOrDefault(item => item.Character.ToLower() == character)!.TokenType;

    public TokenType? RelatedTokenType(string character)
    {
        if (character.ToLower() == ")")
            return TokenState.Items.FirstOrDefault(item => item.Character.ToLower() == "(")!.TokenType;

        return default;
    }   
    
    public string GetToken(string phrase, int length, int index) => phrase.Substring(index, length);



}