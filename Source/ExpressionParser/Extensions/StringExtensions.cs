namespace ExpressionParser.Extensions;

public static class StringExtensions
{
    public static string RemoveSpace(this string expression) => expression.Replace(" ", "", StringComparison.Ordinal);

    public static string Trim(this string expression) => expression.Trim();

    public static string CorrectManipulation(this string expressions, string character, int index) =>
        expressions.Insert(index, character);
}