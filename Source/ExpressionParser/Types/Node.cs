namespace ExpressionParser.Types;

public class Node<T>(T value) where T : IComparable<T>
{
    private Node<T>? _left;
    private Node<T>? _right;

    public void Add(T data)
    {
        if (data.CompareTo(value) < 0)
        {
            if (_left == null)
            {
                _left = new Node<T>(data);
            }
            else
            {
                _left.Add(data);
            }
        }
        else
        {
            if (_right == null)
            {
                _right = new Node<T>(data);
            }
            else
            {
                _right.Add(data);
            }
        }
    }
}