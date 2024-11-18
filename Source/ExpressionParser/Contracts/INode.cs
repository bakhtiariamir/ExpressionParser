using ExpressionParser.Types;

namespace ExpressionParser.Contracts;

public interface INode<in T> where T : IComparable<T>
{
    void Add(T data);

    bool LeftIsNull();
    bool RightIsNull();
}

public interface ITree<in T> where T : IComparable<T>
{
    void Add(T data);
}

public interface IBinaryNode<in T> : INode<T> where T : IComparable<T>
{
    
}

public interface ISingleNode<in T> : INode<T> where T : IComparable<T>
{
    
}