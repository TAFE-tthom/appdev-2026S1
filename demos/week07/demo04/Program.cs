namespace demo04;

class Program
{
    delegate void PrintCallback(string msg);

    static void PrintMessage(string msg)
    {
        Console.WriteLine(msg);
    }

    static int AddTwo(int x, int y)
    {
        return x + y;
    }

    static Func<int> PerformTwiceButNotYet(Func<int, int, int> f,
        int x, int y)
    {
        return () => {
            int result = f(x, y);
            result += f(x, y);
            return result;
        };
    }
    
    static void Main(string[] args)
    {
        // PrintCallback cb = PrintMessage;

        
        // Action<string> cb = PrintMessage;
        // cb("Hello, this is PrintMessage");

        Func<int> callLater = PerformTwiceButNotYet(AddTwo, 2, 2);

        // We can do other things!

        int finalResult = callLater();

        Console.WriteLine(finalResult);
    
    }
}
