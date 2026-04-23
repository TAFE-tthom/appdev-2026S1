namespace demo03;

class Program
{

    static int NumberCompare(int x, int y) {
        return y - x;
    }

    static void PrintArray<T>(T[] elements)
    {
        for(int i = 0; i < elements.Length; i++)
        {
            Console.Write(elements[i] + ", ");
        }
        Console.WriteLine();
    }

    static int NameLengthCompare(string a, string b)
    {
        return a.Length - b.Length;
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

    static void Main(string[] args)
    {
        // Intent - Sort the array of numbers
        // in ascending order
        int[] numbers = { 4, 7, 19, 20, 5, 15 };

        string[] names = {
            "Bob",
            "Alice",
            "Jane",
            "Kelly",
            "Harrison",
            "David"
        };
        // Array.Sort(names, NameCompare);

         Array.Sort(numbers, (x, y) => {
            return x - y;
        });

        PrintArray(numbers);
    
    }
}
