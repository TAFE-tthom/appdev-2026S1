namespace LinkedList.Test;

public class LinkedListTest
{
    [Fact]
    public void LinkedList_Construction()
    {
        LinkedList list = new LinkedList();
        Assert.NotNull(list);
    }

    [Fact]
    public void LinkedList_Size_1()
    {
        LinkedList list = new LinkedList();
        Assert.Equal(0, list.Size);
    }

    [Fact]
    public void LinkedList_Append_Get_1()
    {
        LinkedList list = new LinkedList();
        Assert.Equal(0, list.Size);

        list.Append(1);
        Assert.Equal(1, list.Get(0));
    }

    [Fact]
    public void LinkedList_Append_Remove_1()
    {
        LinkedList list = new LinkedList();
        Assert.Equal(0, list.Size);

        list.Append(1);
        Assert.Equal(1, list.Size);
        Assert.Equal(1, list.Remove(0));
        Assert.Equal(0, list.Size);
    }

    [Fact]
    public void LinkedList_Prepend_Get_1()
    {
        LinkedList list = new LinkedList();
        Assert.Equal(0, list.Size);

        list.Prepend(1);
        Assert.Equal(1, list.Get(0));
    }

    [Fact]
    public void LinkedList_Append_Get_2()
    {
        LinkedList list = new LinkedList();
        Assert.Equal(0, list.Size);

        list.Append(1);
        list.Append(2);
        list.Append(3);
        Assert.Equal(1, list.Get(0));
        Assert.Equal(2, list.Get(1));
        Assert.Equal(3, list.Get(2));
    }

    [Fact]
    public void LinkedList_Prepend_Get_2()
    {
        LinkedList list = new LinkedList();
        Assert.Equal(0, list.Size);

        list.Prepend(1);
        list.Prepend(2);
        list.Prepend(3);
        Assert.Equal(3, list.Get(0));
        Assert.Equal(2, list.Get(1));
        Assert.Equal(1, list.Get(2));
    }

    [Fact]
    public void LinkedList_Prepend_Remove_2()
    {
        LinkedList list = new LinkedList();
        Assert.Equal(0, list.Size);

        list.Prepend(1);
        list.Prepend(2);
        list.Prepend(3);
        Assert.Equal(3, list.Size);
        Assert.Equal(3, list.Remove(0));
        Assert.Equal(1, list.Remove(1));
        Assert.Equal(1, list.Size);
        Assert.Equal(2, list.Remove(0));
        Assert.Equal(0, list.Size);
    }

    [Fact]
    public void LinkedList_Append_Get_3()
    {
        LinkedList list = new LinkedList();
        Assert.Equal(0, list.Size);

        list.Append(1);
        list.Append(2);
        list.Append(3);
        list.Append(6);
        list.Append(10);
        Assert.Equal(1, list.Get(0));
        Assert.Equal(2, list.Get(1));
        Assert.Equal(3, list.Get(2));
        Assert.Equal(6, list.Get(3));
        Assert.Equal(10, list.Get(4));
    }

    [Fact]
    public void LinkedList_Append_Remove_3()
    {
        LinkedList list = new LinkedList();
        Assert.Equal(0, list.Size);

        list.Append(1);
        list.Append(2);
        list.Append(3);
        list.Append(6);
        list.Append(10);
        Assert.Equal(6, list.Remove(3));
        Assert.Equal(1, list.Remove(0));
        Assert.Equal(3, list.Size);
        Assert.Equal(10, list.Remove(2));
        Assert.Equal(2, list.Size);
    }

    [Fact]
    public void LinkedList_Prepend_Get_3()
    {
        LinkedList list = new LinkedList();

        list.Prepend(1);
        list.Prepend(2);
        list.Prepend(3);
        list.Prepend(6);
        list.Prepend(10);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(6, list.Get(1));
        Assert.Equal(3, list.Get(2));
        Assert.Equal(2, list.Get(3));
        Assert.Equal(1, list.Get(4));
        Assert.Equal(5, list.Size);
    }


}
