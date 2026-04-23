namespace demo05;

class Program
{
    static int Fibonacci(int n) {
        if(n == 0) { return 0; }
        else if(n == 1) { return 1; }
        else {
            int r = Fibonacci(n-1) + Fibonacci(n-2);
            return r;
        }
    }

    static void CountDown(int n) {
        if(n <= 0) {
            Console.WriteLine(n);
            return;
        } else {
            Console.WriteLine(n);
            CountDown(n - 1);
        }
    }

    static void Main(string[] args)
    {
        int r = Fibonacci(9);
        Console.WriteLine(r);
    }
}
