using System.Text.RegularExpressions;
using ExpressionParser.Parser.Models;

namespace ExpressionParser.Extensions;

public static class StringExtensions
{
    public static string RemoveSpace(this string expression) => expression.Replace(" ", "", StringComparison.Ordinal);

    public static string Trim(this string expression) => expression.Trim();

    public static bool IsNumeric(string stringValue)
    {
        var pattern = @"^-?[0-9]+(?:\.[0-9]+)?$"; 
        var regex = new Regex(pattern);

        return regex.IsMatch(stringValue);
    }
    public static string CorrectManipulation(this string expressions)
    {
        var finalExpression = expressions;
        var countOfChange = 0;
        var startParentheses =
            TokenState.Items.FirstOrDefault(item => item.TokenType == TokenType.StartParentheses)?.Character ??
            throw new ArgumentNullException();
        var endParentheses =
            TokenState.Items.FirstOrDefault(item => item.TokenType == TokenType.EndParentheses)?.Character ??
            throw new ArgumentNullException();
        var length = expressions.Length;
        for (var i = 0; i < length; i++)   
        {
            if (IsNumeric(expressions[i].ToString()))
            {
                if (expressions.Length - 1 > i)
                {
                    var nextToken = expressions[i + 1].ToString();
                    if (nextToken == startParentheses)
                    {
                        countOfChange++;
                        finalExpression =  finalExpression.Insert(i + countOfChange, "*");
                    }                    
                }
            }
            
            if (expressions[i].ToString() == endParentheses)
            {
                if (expressions.Length - 1 > i)
                {
                    var nextToken = expressions[i + 1].ToString();
                    if (IsNumeric(nextToken))
                    {
                        countOfChange++;
                        finalExpression =  finalExpression.Insert(i + countOfChange, "*");
                    }

                    if (startParentheses == expressions[i + 1].ToString())
                    {
                        countOfChange++;
                        finalExpression =  finalExpression.Insert(i + countOfChange, "*");
                    }
                }
            }
        }

        return finalExpression;
    }
    
    public static string GetToken(this string phrase, int length, int index) => phrase.Substring(index, length);

    public static string? GetNumber(this string phrase, int startIndex, int index, out int diffIndex)
    {
        var number = phrase.Substring(startIndex, index);
        if (StringExtensions.IsNumeric(number) || number == ".")
        {
            var newDiffIndex = diffIndex = index++;
            if (number.Count(c => c == '.') > 1)
            {
                throw new Exception("Number cannot include multi .");
            }
            
            var result = GetNumber(phrase, startIndex, index, out diffIndex);
            if (result == null)
            {
                diffIndex = newDiffIndex;
                return number;
            }
            else
            {
                number = result;
            }

        }
        else
        {
            diffIndex = 0;
            return default;            
        }

        return number;
    }


}
