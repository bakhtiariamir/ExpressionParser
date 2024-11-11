namespace ExpressionParser.Parser.Models;

public class Phrase(string expression)
{
    public string Expression { get; set; } = expression;

    public int TokenCount { get; set; } = 0;

    public List<Token> Tokens { get; set; } = new();
    
    public Parameters Parameters { get; set; } 
    
}