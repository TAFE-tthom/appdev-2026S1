namespace demo06;

class Program
{

    static int GetIndexOfMin<T>(T[] array, int offset,
        Func<T, T, int> compare)
    {
        int index = offset;
        T min = array[offset];
        for(int i = offset+1; i < array.Length; i++)
        {
            if(compare(array[i], min) < 0) {
                min = array[i];
                index = i;
            }
        }

        return index;
    }

    static int NameCompare(string a, string b)
    {
        int len = a.Length;
        if(len > b.Length) {
            len = b.Length;
        }

        int diff = 0;
        for(int i = 0; i < len && diff == 0; i++) {
            diff = a[i] - b[i]; 
        }

        return diff;
    }

    static void PrintArray<T>(T[] elements)
    {
        for(int i = 0; i < elements.Length; i++)
        {
            Console.Write(elements[i] + ", ");
        }
        Console.WriteLine();
    }

    static void Swap<T>(T[] array, int index1, int index2)
    {
        T tmp = array[index1];
        array[index1] = array[index2];
        array[index2] = tmp;
    }

    static void SelectionSort<T>(T[] array,
        Func<T, T, int> compare)
    {
        for(int i = 0; i < array.Length; i++)
        {
            int index = GetIndexOfMin(array, i, compare);
            Swap(array, i, index);
        }
    }

    static void Main(string[] args)
    {
        int[] numbers = { 6, 9, 1, 3, 8, 4, 5 };

        string[] names = {
            "Bob",
            "Alice",
            "Jane",
            "Kelly",
            "Harrison",
            "David"
        };
        SelectionSort(names,
            NameCompare);

        PrintArray(names);
        
    
    }
}
