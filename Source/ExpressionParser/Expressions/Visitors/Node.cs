using ExpressionParser.Types;

namespace ExpressionParser.Expressions.Visitors;



public abstract class Node
{
    public NodeType NodeType { get; set; }
}