using ExpressionParser.Parser.Models;
using ExpressionParser.Parser.Operations;

Console.WriteLine("Hello, World!");

var token = new PhraseParser("(10-2)12-((8+1)-(21 *10 )(90 - 10))/(12 +2)");
//var token = new PhraseParser("((10-2)-(8+1))");
token.Tokenize();
token.Parameterize();
//foreach (var item in items)
//{
//   Console.WriteLine($"Token: {item.Index}, {item.Characters}, {item.Count}, {item.OwnTokenType}, {item.RelatedTokenTypeIndex}");
//}

Console.ReadLine();



