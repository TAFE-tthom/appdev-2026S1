namespace aliasingtrouble;



class LastUsed {

    int[]? numbers = null;

    public void SetLastUsed(int[] numbers) {
        this.numbers = numbers;
    }
    public int[]? GetLastUsed() {
        return numbers;
    }

    public void Discard() {
        numbers = null;
    }
}

class Program
{

    static void PrintNumbers(int[] numbers)
    {
        for(int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + ", ");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {

        int[] numbers1 = { 1, 2, 3, 4, 5 };
        int[] numbers2 = { 6, 7, 8, 9, 10 }; // Address: 0x1000

        LastUsed last = new LastUsed();
        
        last.SetLastUsed(numbers2); // We set numbers (inside last) to 0x1000
        // 37 and before:
        // the array at address 0x1000 had two variables holding this address

        
        // numbers2 = new int[] { 10, 12, 13, 14, 15}; // numbers2 is now (Address: 0x2000)
        // `last` is the only one, keeping the array alive
        last.Discard();
        // last.SetLastUsed(numbers2); // We set numbers (inside last) to 0x1000

        // PrintNumbers(numbers1);
        PrintNumbers(last.GetLastUsed()); // 0x1000
        PrintNumbers(numbers2); //0x2000
    }
}
