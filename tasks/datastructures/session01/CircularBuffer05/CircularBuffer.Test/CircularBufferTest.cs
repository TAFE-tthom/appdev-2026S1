namespace CircularBuffer.Test;

public class CircularBufferTest
{
    [Fact]
    public void CircularBuffer_Construct_Test_1()
    {
        CircularBuffer<string> cb = new CircularBuffer<string>();
        Assert.Equal(0, cb.Size);

    }

    [Fact]
    public void CircularBuffer_Construct_Test_2()
    {
        CircularBuffer<int> cb = new CircularBuffer<int>();
        Assert.Equal(0, cb.Size);

    }

    [Fact]
    public void CircularBuffer_Enqueue_First_Last_1()
    {
        CircularBuffer<int> cb = new CircularBuffer<int>();
        Assert.Equal(0, cb.Size);

        cb.Enqueue(10);
        Assert.Equal(10, cb.First());
        Assert.Equal(10, cb.Last());

    }

    [Fact]
    public void CircularBuffer_Enqueue_First_Last_2()
    {
        CircularBuffer<int> cb = new CircularBuffer<int>();
        Assert.Equal(0, cb.Size);

        cb.Enqueue(10);
        cb.Enqueue(20);
        Assert.Equal(10, cb.First());
        Assert.Equal(20, cb.Last());

    }

    [Fact]
    public void CircularBuffer_Enqueue_First_Last_3()
    {
        CircularBuffer<int> cb = new CircularBuffer<int>();
        Assert.Equal(0, cb.Size);

        cb.Enqueue(10);
        cb.Enqueue(20);
        cb.Enqueue(30);
        cb.Enqueue(40);
        Assert.Equal(10, cb.First());
        Assert.Equal(40, cb.Last());

    }

    [Fact]
    public void CircularBuffer_Enqueue_First_Last_Ref_Check_1()
    {
        CircularBuffer<int> cb = new CircularBuffer<int>();
        Assert.Equal(0, cb.Size);

        int[] intCollection = cb.Collection();

        cb.Enqueue(10);
        cb.Enqueue(20);
        cb.Enqueue(30);
        cb.Enqueue(40);
        Assert.Equal(10, cb.First());
        Assert.Equal(40, cb.Last());
        Assert.Equal(intCollection, cb.Collection());

    }

    [Fact]
    public void CircularBuffer_Enqueue_First_Last_Ref_Check_2()
    {
        CircularBuffer<int> cb = new CircularBuffer<int>();
        Assert.Equal(0, cb.Size);

        int[] intCollection = cb.Collection();

        for(int i = 1; i <= 1000; i++) {
            cb.Enqueue(i);
        }

        Assert.Equal(1, cb.First());
        Assert.Equal(1000, cb.Last());

        Assert.NotEqual(intCollection, cb.Collection());
    }


    [Fact]
    public void CircularBuffer_Enqueue_Dequeue_1()
    {
        CircularBuffer<int> cb = new CircularBuffer<int>();
        Assert.Equal(0, cb.Size);

        cb.Enqueue(10);
        Assert.Equal(10, cb.Dequeue());

    }

    [Fact]
    public void CircularBuffer_Enqueue_Dequeue_2()
    {
        CircularBuffer<int> cb = new CircularBuffer<int>();
        Assert.Equal(0, cb.Size);

        cb.Enqueue(10);
        cb.Enqueue(20);
        Assert.Equal(10, cb.Dequeue());
        Assert.Equal(20, cb.Dequeue());

    }

    [Fact]
    public void CircularBuffer_Enqueue_Dequeue_3()
    {
        CircularBuffer<int> cb = new CircularBuffer<int>();
        Assert.Equal(0, cb.Size);

        cb.Enqueue(10);
        cb.Enqueue(20);
        cb.Enqueue(30);
        cb.Enqueue(40);

        Assert.Equal(10, cb.Dequeue());
        Assert.Equal(20, cb.Dequeue());
        Assert.Equal(30, cb.Dequeue());
        Assert.Equal(40, cb.Dequeue());

    }

    [Fact]
    public void CircularBuffer_Enqueue_Dequeue_4()
    {
        CircularBuffer<int> cb = new CircularBuffer<int>();
        Assert.Equal(0, cb.Size);

        cb.Enqueue(10);
        cb.Enqueue(20);
        cb.Enqueue(30);
        cb.Enqueue(40);
        cb.Enqueue(50);
        cb.Enqueue(60);
        cb.Enqueue(70);
        cb.Enqueue(80);
        cb.Enqueue(90);
        cb.Enqueue(100);
        cb.Enqueue(110);
        cb.Enqueue(120);
        cb.Dequeue();
        cb.Dequeue();
        cb.Dequeue();
        cb.Dequeue();
        cb.Enqueue(130);
        cb.Enqueue(140);
        cb.Enqueue(150);
        cb.Enqueue(160);
        cb.Enqueue(170);
        cb.Enqueue(180);
        cb.Enqueue(190);
        cb.Dequeue();
        cb.Dequeue();
        cb.Dequeue();
        cb.Dequeue();
        cb.Dequeue();
        cb.Dequeue();
        cb.Dequeue();
        cb.Dequeue();
        cb.Dequeue();
        cb.Dequeue();
        cb.Dequeue();
        cb.Dequeue();
        cb.Dequeue();

        Assert.Equal(180, cb.First());
        Assert.Equal(190, cb.Last());
        Assert.Equal(cb, cb.Collection());

    }
}
