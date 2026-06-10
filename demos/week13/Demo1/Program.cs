namespace Demo1;

class Program
{
    static void Main(string[] args)
    {
        // int x = 10;
        // int y = 20;

        // int z = x + y; //We could access x and y from RAM and
            // Perform ADD on x and y
            // Write back to RAM

        for(int i = 0; i < 1000000; i++) {
            int x = 10 + i;
            int y = 20 + i;

            int z = x + y; //We could access x and y from RAM and
                // Perform ADD on x and y
                // Write back to RAM
        }
    }
}
