namespace DynamicArray;

public class DynamicArray<T>
{

	public int Size { get; private set; } = 0;
	public int Capacity { get; private set; } = 16;
	private T[] array;

	public DynamicArray()
	{
		array = new T[Capacity];
	}

	private void Resize() 
	{

	}

	public void Append(T item)
	{

	}

	public T? Get(int index)
	{
		return null;
	}

	public T? Remove(int index)
	{
		if(index >= 0 && index < Size) {


			Size--;
		}
		return null;
	}

}
