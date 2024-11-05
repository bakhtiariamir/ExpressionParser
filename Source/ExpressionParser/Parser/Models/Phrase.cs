namespace ExpressionParser.Parser.Models;

public class Phrase
{
    public string Expression { get; set; } = string.Empty;

    public int TokenCount { get; set; } = 0;

    public List<Token> Tokens { get; set; } = new();
    
    
}