namespace DynamicArray.Test;

public class DynamicArrayTest
{
    [Fact]
    public void DynamicArray_Construct_1()
    {
	DynamicArray<string> dar = new DynamicArray<string>();
	
	Assert.NotNull(dar);
	Assert.Equal(0, dar.Size);
	

    }
    
    [Fact]
    public void DynamicArray_Construct_2()
    {
	DynamicArray<int> dar = new DynamicArray<int>();
	
	Assert.NotNull(dar);
	Assert.Equal(0, dar.Size);
	

    }

    [Fact]
    public void DynamicArray_Append_Get_1()
    {
	DynamicArray<int> dar = new DynamicArray<int>();
	
	Assert.NotNull(dar);
	Assert.Equal(0, dar.Size);
	
	dar.Append(10);
	Assert.Equal(1, dar.Size);
	Assert.Equal(10, dar.Get(0));

	

    }

    [Fact]
    public void DynamicArray_Append_Get_2()
    {
	DynamicArray<int> dar = new DynamicArray<int>();
	
	Assert.NotNull(dar);
	Assert.Equal(0, dar.Size);
	
	dar.Append(10);
	dar.Append(20);
	dar.Append(30);
	Assert.Equal(3, dar.Size);
	Assert.Equal(10, dar.Get(0));
	Assert.Equal(20, dar.Get(1));
	Assert.Equal(30, dar.Get(2));	

    }

    [Fact]
    public void DynamicArray_Append_Remove_1()
    {
	DynamicArray<int> dar = new DynamicArray<int>();
	
	Assert.NotNull(dar);
	Assert.Equal(0, dar.Size);
	
	dar.Append(10);
	Assert.Equal(1, dar.Size);
	Assert.Equal(10, dar.Remove(0));
	Assert.Equal(0, dar.Size);	

    }

    [Fact]
    public void DynamicArray_Append_Remove_2()
    {
	DynamicArray<int> dar = new DynamicArray<int>();
	
	Assert.NotNull(dar);
	Assert.Equal(0, dar.Size);
	
	dar.Append(10);
	dar.Append(20);
	dar.Append(30);
	Assert.Equal(3, dar.Size);
	Assert.Equal(30, dar.Remove(2));
	Assert.Equal(10, dar.Remove(0));
	Assert.Equal(20, dar.Remove(0));	
	Assert.Equal(0, dar.Size);

    }



    [Fact]
    public void DynamicArray_Append_Get_3()
    {
	DynamicArray<int> dar = new DynamicArray<int>();
	
	Assert.NotNull(dar);
	Assert.Equal(0, dar.Size);
	
	dar.Append(10);
	dar.Append(20);
	dar.Append(30);
	dar.Append(40);
	dar.Append(50);
	dar.Append(60);
	Assert.Equal(6, dar.Size);
	Assert.Equal(10, dar.Get(0));
	Assert.Equal(20, dar.Get(1));
	Assert.Equal(30, dar.Get(2));	
	Assert.Equal(40, dar.Get(3));
	Assert.Equal(50, dar.Get(4));
	Assert.Equal(60, dar.Get(5));

    }

    [Fact]
    public void DynamicArray_Append_Get_4()
    {
	DynamicArray<int> dar = new DynamicArray<int>();
	
	Assert.NotNull(dar);
	Assert.Equal(0, dar.Size);

	for(int i = 1; i <= 1000; i++) {
		dar.Append(i * 10);
	
	}
	
	Assert.Equal(1000, dar.Size);

	for(int i = 1; i <= 1000; i++) {
		Assert.Equal(i * 10, dar.Get(i-1));	
	}

    }

    [Fact]
    public void DynamicArray_Append_Remove_Zero_4()
    {
	DynamicArray<int> dar = new DynamicArray<int>();
	
	Assert.NotNull(dar);
	Assert.Equal(0, dar.Size);

	for(int i = 1; i <= 1000; i++) {
		dar.Append(i * 10);
	
	}
	
	Assert.Equal(1000, dar.Size);

	for(int i = 1; i <= 1000; i++) {
		Assert.Equal(i * 10, dar.Remove(0));	
	}

    }





}
