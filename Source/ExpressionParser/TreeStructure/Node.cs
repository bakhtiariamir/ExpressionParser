using ExpressionParser.Contracts;

namespace ExpressionParser.TreeStructure;

public abstract class Node<T, TNode> where TNode : INode<T>  where T : IComparable<T>
{
    public T Value { get; set; }

    protected Node()
    {
    }

    protected  Node(T value)
    {
        Value = value;
    }
    
    protected TNode? Left { get; set; }
    protected TNode? Right { get; set; }

    public void Add(T data)
    {
        if (data.CompareTo(Value) < 0)
        {
            if (LeftIsNull())
            {
                Left = AddNode(data);
            }
            else
            {
                Left.Add(data);
            }
        }
        else
        {
            if (RightIsNull())
            {
                Right = AddNode(data);
            }
            else
            {
                Right.Add(data);
            }
        }
    }

    protected abstract TNode AddNode(T data); 
    
    public bool LeftIsNull() => Left == null;
    public bool RightIsNull() => Right == null;
}

public class BinaryNode<T> : Node<T, BinaryNode<T>>, IBinaryNode<T> where T : IComparable<T>
{
    protected override BinaryNode<T> AddNode(T data)
    {
        if (LeftIsNull())
        {
            Left = new BinaryNode<T>();
        }

        if (RightIsNull())
        {
            Right = new BinaryNode<T>();
        }

        throw new Exception();
    }
}

public class SingleNode<T> : Node<T, SingleNode<T>>, ISingleNode<T> where T : IComparable<T>
{
    protected override SingleNode<T> AddNode(T data)
    {
        throw new NotImplementedException();
    }
}