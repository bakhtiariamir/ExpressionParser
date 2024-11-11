using System.Collections;
using System.Text.RegularExpressions;
using ExpressionParser.Extensions;
using ExpressionParser.Parser.Models;

namespace ExpressionParser.Parser.Operations;

public class PhraseParser(string phrase)
{
    private readonly Phrase _phrase = new Phrase(phrase);

    public void Tokenize()
    {
        var startParenthesesStack = new Stack<int>(); 
        var tokenize = new List<Token>();
        _phrase.Expression = _phrase.Expression.RemoveSpace().Trim().CorrectManipulation();
        var length = _phrase.Expression.Length;
        for (int i = 0; i < length; i++)
        {
            var startParentheses = TokenState.Items.FirstOrDefault(row => row.TokenType == TokenType.StartParentheses)
                ?.Character ?? throw new ArgumentNullException();
            var endParentheses = TokenState.Items.FirstOrDefault(row => row.TokenType == TokenType.EndParentheses)
                ?.Character ?? throw new ArgumentNullException();            
            
            foreach (var item in TokenState.Items)
            {
                var countOfCharacter = item.Character.Length;
                var token = _phrase.Expression.GetToken(countOfCharacter, i);
                if (countOfCharacter > 1 && token.FirstOrDefault() != item.Character.FirstOrDefault())
                    break;
                
                var relatedTokenTypeIndex = 0;
                if (StringExtensions.IsNumeric(token))
                {
                    var number = _phrase.Expression.GetNumber(i, 1, out int diffIndex);
                    if (number != null)
                    {
                        tokenize.Add(new Token(number, i,  TokenType.Number, relatedTokenTypeIndex));
                        if (diffIndex >= 1)
                        {
                            i = i + (diffIndex-1) == 0 ? 1 : i = (diffIndex-1)+ i;
                        }
                        break;
                    }
                    else
                    {
                        tokenize.Add(new Token(item.Character, 0,GetTokenType(item.Character), relatedTokenTypeIndex));
                        break;
                    }
                }
                else if (string.Equals(item.Character, token , StringComparison.CurrentCultureIgnoreCase))
                {
                    var diffIndex = countOfCharacter - 1;
                    if (diffIndex > 1)
                    {
                        i = i + diffIndex  == 0 ? 1 : i + diffIndex;
                    }
                    if (item.Character == endParentheses)
                    {
                        relatedTokenTypeIndex = startParenthesesStack.Pop();
                        tokenize.Add(new Token(item.Character, i,GetTokenType(item.Character), relatedTokenTypeIndex));
                        break;
                    }
                    else if (item.Character == startParentheses)
                    {
                        startParenthesesStack.Push(i);
                        tokenize.Add(new Token(item.Character, startParenthesesStack.Count+1, GetTokenType(item.Character), relatedTokenTypeIndex));
                        break;
                    }
                    else
                    {
                        tokenize.Add(new Token(item.Character, 0,GetTokenType(item.Character), relatedTokenTypeIndex));
                        break;
                    }
                }
            } 
        }
        _phrase.Tokens = tokenize;
        _phrase.TokenCount = tokenize.Count;
    }

    public void Parameterize(int level = 1)
    {
        var startToken = TokenState.Items.FirstOrDefault(item => item.Character == "(") ??
                         throw new Exception("Start token is not exists");
        var endToken = TokenState.Items.FirstOrDefault(item => item.Character == ")") ??
                         throw new Exception("End token is not exists");
        var checkParameter = _phrase.Parameters.Phrase.Contains('(');
        if (checkParameter)
        {
            var firstParentheses = _phrase.Tokens.FirstOrDefault(item => item.Characters == startToken.Character) ??
                                   throw new Exception("Start token not exists");
            var endParentheses = _phrase.Tokens.FirstOrDefault(item => item.Characters == endToken.Character) ??   
                         throw new Exception("Start token is not exists");
            if (!_phrase.Parameters.Phrase.Substring(firstParentheses.Index + 1, endParentheses.Index - 1)
                .Contains(startToken.Character))
            {
                var tokens = _phrase.Tokens
                    .Where(item => item.OwnTokenType != TokenType.Number)
                    .Join(TokenState.TokenPriorities, token => token.OwnTokenType, priority => priority.Token,
                        (token, priority) => new
                        {
                            Token = token.OwnTokenType,
                            RelatedToken = token.RelatedTokenTypeIndex,
                            Character = token.Characters,
                            Priority = priority.Priority,
                            Associativity = priority.Associativity
                        }).ToList().OrderBy(item => item.Priority);
                foreach (var token in tokens)
                {
                    
                }
            }
            
            
            
            var startParentheses = TokenState.Items.FirstOrDefault(row => row.TokenType == TokenType.StartParentheses)
                ?.Character ?? throw new ArgumentNullException();

            var characterLast = TokenState.Items[^1];
            if (_phrase.Tokens.Count <= 0)
            {
                throw new Exception();
            }

            var scopes = new List<ParameterScope>();
            var starts = _phrase.Tokens.Where(item => item.Characters == "(").ToList();
            if (starts is { Count: > 0 })
            {
                var count = 1;
                foreach (var start in starts)
                {
                    var end = _phrase.Tokens.FirstOrDefault(item =>
                        item.Characters == startParentheses && item.RelatedTokenTypeIndex == start.Index);
                    if (end is null)
                        throw new Exception();

                    var scopeLength = (end.Index - start.Index) - 1;
                    if (scopeLength > 0)
                    {
                        var scopePhrase = _phrase.Expression.Substring(start.Index, scopeLength + 1);

                        checkParameter = true;
                        scopes.Add(new ParameterScope($"A{count++}", [start, end], scopePhrase));
                    }
                    else
                    {
                        checkParameter = false;
                    }
                }

                if (checkParameter)
                {
                    level += level;
                    _phrase.Parameters = new Parameters()
                    {
                        Scopes = scopes
                    };   
                }
                else
                {
                    return;
                }
            }
                
        }

    }

    private static TokenType? GetTokenType(string character) => TokenState.Items.FirstOrDefault(item => item.Character.ToLower() == character)!.TokenType;

    public TokenType? RelatedTokenType(string character)
    {
        if (character.ToLower() == ")")
            return TokenState.Items.FirstOrDefault(item => item.Character.ToLower() == "(")!.TokenType;

        return default;
    }



}
