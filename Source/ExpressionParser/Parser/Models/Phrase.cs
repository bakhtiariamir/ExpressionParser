namespace ExpressionParser.Parser.Models;

public class Phrase(string expression)
{
    public string Expression { get; set; } = expression;

    public int TokenCount { get; set; } = 0;

    public List<Token> Tokens { get; set; } = [];

    public Parameters Parameters { get; set; } = new();
}
