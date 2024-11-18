using ExpressionParser.Contracts;

namespace ExpressionParser.TreeStructure;

public class Tree<T>  where T : ITree<T>, IComparable<T>
{
    private INode<T> _root { get; set; }

    public void Add(T value)
    {
        if(_root.LeftIsNull())
        {
            _root.Add(value);
        }
        else
        {
            _root.Add(value);
        }
    }
}