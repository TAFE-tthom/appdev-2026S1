namespace CircularBuffer;

public class CircularBuffer<T>
{

    public static int DEFAULT_SIZE { get; } = 16;

    public int Size { get; private set; }

    private int index = 0;
    private T[] collection = new T[DEFAULT_SIZE];

    public CircularBuffer() : this(DEFAULT_SIZE) { }

    public CircularBuffer(int size)
    {
        collection = new T[size];
    }

    private void Resize() {
        T[] nCollection = new T[collection.Length * 2];

        for(int i = 0; i < Size; i++)
        {
            nCollection[(index + i) % nCollection.Length]
                = collection[(index + i) % collection.Length];
        }
        collection = nCollection;
    }

    public T[] Collection()
    {
        return collection;
    }

    public void Enqueue(T item)
    {
        if(Size >= collection.Length) {
            Resize();
        }
        collection[(index + Size) % collection.Length] = item;
        Size++;

    }

    public T? First() {
        if(Size > 0) {
            T item = collection[index];
            return item;
        } else {
            return default(T);
        }
    }

    public T? Last() {
        if(Size > 0) {
            T item = collection[(index + Size) % collection.Length];
            return item;
        } else {
            return default(T);
        }
    }

    public T? Dequeue()
    {
        if(Size > 0) {
            T item = collection[index];

            index = (index + 1) % collection.Length;
            Size--;

            return item;
        } else {
            return default(T);
        }
    }





}
