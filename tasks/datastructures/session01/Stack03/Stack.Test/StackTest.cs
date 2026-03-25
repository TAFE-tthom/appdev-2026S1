namespace Stack.Test;

public class StackTest
{
    [Fact]
    public void Stack_Construct_String()
    {
        Stack<string> stack = new Stack<string>();

        Assert.NotNull(stack);
        Assert.Equal(0, stack.Length());

    }

    [Fact]
    public void Stack_Construct_int()
    {
        Stack<int> stack = new Stack<int>();

        Assert.NotNull(stack);
        Assert.Equal(0, stack.Length());

    }

    [Fact]
    public void Stack_Pop_Empty()
    {
        Stack<int> stack = new Stack<int>();

        Assert.NotNull(stack);
        Assert.Equal(0, stack.Length());
        Assert.Equal(0, stack.Pop());
        

    }

    [Fact]
    public void Stack_Peek_Empty()
    {
        Stack<int> stack = new Stack<int>();

        Assert.NotNull(stack);
        Assert.Equal(0, stack.Length());
        Assert.Equal(0, stack.Peek());

    }

    [Fact]
    public void Stack_Push_Peek_1()
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(1);
        Assert.Equal(1, stack.Length());
        Assert.Equal(1, stack.Peek());

    }

    [Fact]
    public void Stack_Push_Pop_1()
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(1);
        Assert.Equal(1, stack.Length());
        Assert.Equal(1, stack.Pop());
        Assert.Equal(0, stack.Length());

    }

    [Fact]
    public void Stack_Push_Peek_2()
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(1);
        Assert.Equal(1, stack.Length());
        Assert.Equal(1, stack.Peek());

        stack.Push(3);
        Assert.Equal(2, stack.Length());
        Assert.Equal(3, stack.Peek());

    }

    [Fact]
    public void Stack_Push_Pop_2()
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(1);
        Assert.Equal(1, stack.Length());
        Assert.Equal(1, stack.Peek());

        stack.Push(3);
        Assert.Equal(2, stack.Length());
        Assert.Equal(3, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.Equal(0, stack.Length());

    }

    [Fact]
    public void Stack_Push_Peek_3()
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(1);
        Assert.Equal(1, stack.Length());
        Assert.Equal(1, stack.Peek());

        stack.Push(3);
        Assert.Equal(2, stack.Length());
        Assert.Equal(3, stack.Peek());

        stack.Push(5);
        Assert.Equal(3, stack.Length());
        Assert.Equal(5, stack.Peek());

        stack.Push(9);
        Assert.Equal(4, stack.Length());
        Assert.Equal(9, stack.Peek());

    }

    [Fact]
    public void Stack_Push_Pop_Mix()
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(1);
        Assert.Equal(1, stack.Length());
        Assert.Equal(1, stack.Peek());

        stack.Push(3);
        Assert.Equal(2, stack.Length());
        Assert.Equal(3, stack.Peek());

        stack.Push(5);
        Assert.Equal(3, stack.Length());
        Assert.Equal(5, stack.Pop());
        Assert.Equal(2, stack.Length());


        stack.Push(9);
        Assert.Equal(4, stack.Length());

        Assert.Equal(9, stack.Pop());
        Assert.Equal(2, stack.Length());
        Assert.Equal(3, stack.Pop());
        Assert.Equal(1, stack.Pop());

    }


}
