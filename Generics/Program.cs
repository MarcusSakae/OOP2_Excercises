using System.Diagnostics;

class Stack<T>
{
    private T[] items;
    public int Count { get; private set; }

    public Stack()
    {
        items = new T[0];
        Count = 0;
    }

    public void Push(T item)
    {
        var newItems = new T[Count + 1];
        newItems[0] = item;
        for (int i = 0; i < Count; i++)
        {
            newItems[i + 1] = items[i];
        }
        items = newItems;
        Count++;

    }

    public T Pop()
    {
        var item = items[0];
        items = items[1..];
        Count = items.Count();
        return item;
    }

    public T Peek()
    {
        return items[0];
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        var stack = new Stack<string>();
        stack.Push("Hej");
        stack.Push("på");
        stack.Push("dej!");
 
        Console.WriteLine("peek");
        Debug.Assert(stack.Peek() == "dej!");

        Console.WriteLine("pop");
        Debug.Assert(stack.Pop() == "dej!");

        Console.WriteLine("peek");
        Debug.Assert(stack.Peek() == "på");
 
        Console.WriteLine("count");
        Debug.Assert(stack.Count == 2);
    }
}