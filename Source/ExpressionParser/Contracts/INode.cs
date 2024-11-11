using ExpressionParser.Types;

namespace ExpressionParser.Contracts;

public interface INode
{
    NodeType NodeType { get; set; }
}
