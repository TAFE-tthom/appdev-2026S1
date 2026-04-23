namespace genericsexample01;


class CircularBuffer<T> {

    private T[]? data = default(T[]);

    private int index = 0;
    private int size = 0;
    private int capacity = 0;
    

    public CircularBuffer(int capacity) {
        this.capacity = capacity;
        this.data = new T[capacity];
    }

    public void Enqueue(T obj) {
        if(size < capacity) {
            data[(index + size) % capacity] = obj;
            size++;
        }
    }

    public T? Dequeue() {
        T? result = default(T);
        if(size == 0) {
            return result;
        } else {
            result = data[index];
            index = (index + 1) % capacity;
            size--;
            return result;
        }
    }

    public bool IsEmpty() {
        return size == 0;
    }
    
}

class Program
{
    static void Main(string[] args)
    {
        CircularBuffer<int> intQueue
            = new CircularBuffer<int>(8);
        CircularBuffer<string> stringQueue
            = new CircularBuffer<string>(8);

        for(int i = 0; i < 8; i++) {
            intQueue.Enqueue(i * 100);
        }

        while(!intQueue.IsEmpty()) {
            int obj = intQueue.Dequeue();
            Console.WriteLine(obj);
        }
        
    }
}
