using System.Collections;
using System.Text.RegularExpressions;
using ExpressionParser.Extensions;
using ExpressionParser.Parser.Models;
using ExpressionParser.TreeStructure;

namespace ExpressionParser.Parser.Operations;

public class PhraseParser(string phrase)
{
    private readonly Phrase _phrase = new(phrase);
    private readonly TokenTypeState _startToken = TokenState.Items.FirstOrDefault(item => item.Character == "(") ??
                     throw new Exception("Start token is not exists");
    private readonly TokenTypeState _endToken = TokenState.Items.FirstOrDefault(item => item.Character == ")") ??
                                               throw new Exception("End token is not exists");
    public void Tokenize()
    {
        var startParenthesesStack = new Stack<int>();
        var tokenize = new List<Token>();
        _phrase.Expression = _phrase.Expression.RemoveSpace().Trim().CorrectManipulation();
        var length = _phrase.Expression.Length;
        for (var i = 0; i < length; i++)
        {
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
                        tokenize.Add(new Token(number, i, TokenType.Number, relatedTokenTypeIndex));
                        if (diffIndex >= 1)
                        {
                            i = i + (diffIndex - 1) == 0 ? 1 : i = (diffIndex - 1) + i;
                        }

                        break;
                    }
                    else
                    {
                        tokenize.Add(new Token(item.Character, 0, TokenExtensions.GetTokenType(item.Character), relatedTokenTypeIndex));
                        break;
                    }
                }
                else if (string.Equals(item.Character, token, StringComparison.CurrentCultureIgnoreCase))
                {
                    var diffIndex = countOfCharacter - 1;
                    if (diffIndex > 1)
                    {
                        i = i + diffIndex == 0 ? 1 : i + diffIndex;
                    }

                    if (item.Character == _endToken.Character)
                    {
                        relatedTokenTypeIndex = startParenthesesStack.Pop();
                        tokenize.Add(new Token(item.Character, i, TokenExtensions.GetTokenType(item.Character), relatedTokenTypeIndex));
                        break;
                    }
                    else if (item.Character == _startToken.Character)
                    {
                        startParenthesesStack.Push(i);
                        tokenize.Add(new Token(item.Character, startParenthesesStack.Count + 1,
                            TokenExtensions.GetTokenType(item.Character), relatedTokenTypeIndex));
                        break;
                    }
                    else
                    {
                        tokenize.Add(new Token(item.Character, 0, TokenExtensions.GetTokenType(item.Character), relatedTokenTypeIndex));
                        break;
                    }
                }
            }
        }

        _phrase.Tokens = tokenize;
        _phrase.TokenCount = tokenize.Count;
    }

    public void Parameterize()
    {
        for (var i = 0; i < _phrase.TokenCount; i++)
        {
            if (_phrase.Tokens[i].OwnTokenType == _startToken.TokenType)
            {
                for (var j = i+1; j < _phrase.TokenCount; j++)
                {
                    if (_phrase.Tokens[j].OwnTokenType == _endToken.TokenType)
                    {
                        var startIndex = i + 1;
                        var endIndex = j - 1;
                        ContentNormalize(startIndex, endIndex);
                    }
                    else if (_phrase.Tokens[j].OwnTokenType == _startToken.TokenType)
                    {
                     break;   
                    }
                    else
                    {
                        //check if has not end parentheses
                    }
                }
            }
        }
        
        if (_phrase.Expression.Contains(_startToken.Character))
            Parameterize();
    }

    public void ContentNormalize(int startIndex, int endIndex, Node<ParameterScope> node, int level = 1)
    {
        if (_phrase.Parameters.Phrase.Contains(_startToken.Character))
        {
                if (!_phrase.Parameters.Phrase.Substring(startIndex + 1, endIndex - 1)
                        .Contains(_startToken.Character))
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
                            }).ToList().OrderBy(item => item.Priority).ToList();
                    var tokenLength = tokens?.Count;
                    if (tokens is { Count: > 0 })
                    {
                        for (var i = 0; i < tokenLength; i++)
                        {
                            var token = tokens[i];
                            if (token.Associativity == Associativity.LeftToRight)
                            {
                                if (node.LeftIsNull())
                                {
                                    var right = new object();
                                    var left = new object();
                                    var center = new object();
                                    if (i - 1 <= endParentheses.Index && i - 1 >= firstParentheses.Index)
                                    { 
                                        left = new
                                        {
                                            Token = _phrase.Tokens[i - 1],
                                        };
                                    }
                                    else
                                    {
                                        throw new Exception("Left token cannot be null.");
                                    }
                                
                                    center = new
                                    {
                                        Token = _phrase.Tokens[i]
                                    };

                                    if (i + 1 <= endParentheses.Index && i + 1 >= firstParentheses.Index)
                                    {
                                        right = new
                                        {
                                            Token = _phrase.Tokens[i + 1]
                                        };
                                    }
                                
                                    node = new
                                    {
                                        Left = left,
                                        Center = center,
                                        Right = right
                                    };
                                }
                                else if (node.Right == null)
                                {
                                    
                                }
                                else
                                {
                                    
                                }
                                
                                
                                ////

                            }
                            else
                            {
                                var right = new object();
                                var left = new object();
                                var center = new object();
                                if (i - 1 <= endParentheses.Index && i - 1 >= firstParentheses.Index)
                                { 
                                    right = new
                                    {
                                        Token = _phrase.Tokens[i - 1],
                                    };
                                }
                                else
                                {
                                    throw new Exception("Right token cannot be null.");
                                }
                                
                                center = new
                                {
                                    Token = _phrase.Tokens[i]
                                };

                                if (i + 1 <= endParentheses.Index && i + 1 >= firstParentheses.Index)
                                {
                                    left = new
                                    {
                                        Token = _phrase.Tokens[i + 1]
                                    };
                                }
                                
                                node = new
                                {
                                    Left = left,
                                    Center = center,
                                    Right = right
                                };
                            }
                        }   
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


}