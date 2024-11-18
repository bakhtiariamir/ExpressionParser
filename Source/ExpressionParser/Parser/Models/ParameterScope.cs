using System.Linq.Expressions;

namespace ExpressionParser.Parser.Models;

public sealed class ParameterScope(string name, List<Token> tokens, string phrase, ExpressionType expressionType)
    : IComparable<ParameterScope>
{
    public string Name { get; set; } = name;
    public List<Token> Tokens { get; set; } = tokens;
    public string Phrase { get; set; } = phrase;
    public ExpressionType ExpressionType { get; set; } = expressionType;
    public int CompareTo(ParameterScope? other)
    {
        if (object.ReferenceEquals(other, null))
            return 1;

        return Name.CompareTo(other);
    }
}