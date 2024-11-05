namespace ExpressionParser.Types;

public class Tree<T>  where T : IComparable<T>
{
    private Node<T>? _root;

    public void Add(T value)
    {
        if(_root == null)
        {
            _root = new Node<T>(value);
        }
        else
        {
            _root.Add(value);
        }
    }
}