namespace ExpressionParser.Parser.Models;

public class Parameters
{
    public List<ParameterScope> Scopes { get; set; } = new();
    public string Phrase { get; set; } = string.Empty;
}