namespace IntQueue.Test;

public class IntQueueTest
{
    [Fact]
    public void IntQueue_Construct_Test()
    {
        IntQueue q = new IntQueue();
        Assert.Equal(0, q.Length());
        Assert.NotNull(q);

    }

    [Fact]
    public void IntQueue_Enqueue_Peek_Null()
    {

        IntQueue q = new IntQueue();
        Assert.Equal(0, q.Length());

        Assert.Null(q.Peek());

    }

    [Fact]
    public void IntQueue_Enqueue_Dequeue_Null()
    {

        IntQueue q = new IntQueue();
        Assert.Equal(0, q.Length());

        Assert.Null(q.Dequeue());

    }

    [Fact]
    public void IntQueue_Enqueue_Peek_1()
    {

        IntQueue q = new IntQueue();
        Assert.Equal(0, q.Length());

        q.Enqueue(1);
        Assert.Equal(1, q.Length());
        Assert.Equal(1, q.Peek());

    }


    [Fact]
    public void IntQueue_Enqueue_Peek_2()
    {
        IntQueue q = new IntQueue();
        Assert.Equal(0, q.Length());

        q.Enqueue(1);
        Assert.Equal(1, q.Length());

        q.Enqueue(24);
        Assert.Equal(2, q.Length());
        Assert.Equal(1, q.Peek());

    }

    [Fact]
    public void IntQueue_Enqueue_Peek_3()
    {

        IntQueue q = new IntQueue();
        Assert.Equal(0, q.Length());

        q.Enqueue(1);
        Assert.Equal(1, q.Length());

        q.Enqueue(24);
        Assert.Equal(2, q.Length());
        Assert.Equal(1, q.Peek());

        q.Enqueue(54);

        q.Enqueue(38);
        q.Enqueue(90);
        q.Enqueue(142);
        Assert.Equal(6, q.Length());
        Assert.Equal(1, q.Peek());

    }

    [Fact]
    public void IntQueue_Enqueue_Dequeue_1()
    {

        IntQueue q = new IntQueue();
        Assert.Equal(0, q.Length());

        q.Enqueue(1);
        Assert.Equal(1, q.Length());
        Assert.Equal(1, q.Dequeue());
        Assert.Equal(0, q.Length());
    }


    [Fact]
    public void IntQueue_Enqueue_Dequeue_2()
    {
        IntQueue q = new IntQueue();
        Assert.Equal(0, q.Length());

        q.Enqueue(1);
        Assert.Equal(1, q.Length());

        q.Enqueue(24);
        Assert.Equal(2, q.Length());
        Assert.Equal(1, q.Peek());
        Assert.Equal(1, q.Dequeue());
        Assert.Equal(1, q.Length());
        Assert.Equal(24, q.Dequeue());
        Assert.Equal(0, q.Length());

    }

    [Fact]
    public void IntQueue_Enqueue_Dequeue_3()
    {

        IntQueue q = new IntQueue();
        Assert.Equal(0, q.Length());

        q.Enqueue(1);
        Assert.Equal(1, q.Length());

        q.Enqueue(24);
        Assert.Equal(2, q.Length());
        Assert.Equal(1, q.Peek());

        q.Enqueue(54);

        q.Enqueue(38);
        q.Enqueue(90);
        q.Enqueue(142);
        Assert.Equal(6, q.Length());
        Assert.Equal(1, q.Peek());
        Assert.Equal(1, q.Dequeue());
        Assert.Equal(5, q.Length());
        Assert.Equal(24, q.Dequeue());
        Assert.Equal(4, q.Length());
        Assert.Equal(54, q.Dequeue());
        Assert.Equal(3, q.Length());
        Assert.Equal(38, q.Dequeue());
        Assert.Equal(2, q.Length());
        Assert.Equal(90, q.Dequeue());
        Assert.Equal(1, q.Length());
        Assert.Equal(142, q.Dequeue());
        Assert.Equal(0, q.Length());

    }
}
