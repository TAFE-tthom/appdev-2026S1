
namespace Demo2;

class Program
{
    static int[] GenerateIntegers(int n) {

        Random rand = new Random();
        int[] numbers = new int[n];

        for(int i = 0; i < n; i++) {
            numbers[i] = rand.Next();
        }
        return numbers;
    }


    static void SequentialAccess(int n, int[] array, int[] retrieval) {
        for(int i = 0; i < array.Length; i++) {
            retrieval[i] = array[i];
        }
        
    }

    static void BlockSequentialAccess(int n, int[] array, int[] retrieval)
    {
        
    }


    static void CacheLineJumpAccess(int n, int[] array, int[] retrieval) {
        int count = 0;
        for(int k = 0; k < 16; k++) {
            for(int index = k; index < array.Length; index += 16) {
                retrieval[count] = array[index];
                count++;
            }
        }

        
        
    }

    static void Main(string[] args) {

        int count = 8192 * 1024 * 128;
    
        int[] randomNumbers = GenerateIntegers(count);
        int[] results = new int[count];

        CacheLineJumpAccess(count, randomNumbers, results);
    }

    // static void Main(string[] args)
    // {
    //     int[] numbers = new int[] {
    //         1, 2, 3, 4, 5, 6, 7, 8, 9, 0,
    //         1, 2, 3, 4, 5, 6, 7, 8, 9, 0,
    //         1, 2, 3, 4, 5, 6, 7, 8, 9, 0,
    //         1, 2, 3, 4, 5, 6, 7, 8, 9, 0,
    //         1, 2, 3, 4, 5, 6, 7, 8, 9, 0,
    //         1, 2, 3, 4, 5, 6, 7, 8, 9, 0,
    //         1, 2, 3, 4, 5, 6, 7, 8, 9, 0,
    //         1, 2, 3, 4, 5, 6, 7, 8, 9, 0,
    //         1, 2, 3, 4, 5, 6, 7, 8, 9, 0,
    //         1, 2, 3, 4, 5, 6, 7, 8, 9, 0,
    //         1, 2, 3, 4, 5, 6, 7, 8, 9, 0,
    //         1, 2, 3, 4, 5, 6, 7, 8, 9, 0,
    //         1, 2, 3, 4, 5, 6, 7, 8, 9, 0,
    //         1, 2, 3, 4, 5, 6, 7, 8, 9, 0,
    //     };

    //     //If we do the following
    //     // int x = numbers[0]; // as soon as you access index 0
    //         // The CPU gets [1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6]

    
    
    //     for(int i = 0; i < numbers.Length; i++) {
    //         int y = numbers[i*16]; 
    //     }
    //     // Hit on RAM (Slowest)
    //     // Hit on RAM (Slowest)
    //     // Hit on RAM (Slowest)
    //     // Hit on RAM (Slowest)
    //     // Hit on RAM (Slowest)
    //     // Hit on RAM (Slowest)
    //     // Hit on RAM (Slowest)
    //     // Hit on RAM (Slowest)
    //     // Hit on RAM (Slowest)
    //     // Hit on RAM (Slowest)
    //     // Hit on RAM (Slowest)
    //     // Hit on RAM (Slowest)
    //     // Hit on RAM (Slowest)
    //     // Hit on RAM (Slowest)

    //     // 1*RAM access + (N-1 accesses * L1 latency) = 15 * 5ns + 84ns
    //     // = 75ns + 84ns = 159ns
    //     // N accesses * RAM latency = 1344ns
    //     // 

        

    // } 
}
