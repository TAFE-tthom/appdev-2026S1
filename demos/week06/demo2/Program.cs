namespace demo2;

class Program
{
    static void A() {
        
        Console.WriteLine("A Starts");
        // throw new Exception("This happens in A!");
        Console.WriteLine("A Ends");
    }
    
    
    static void B() {
        Console.WriteLine("B Starts");
        A();
        Console.WriteLine("B Ends");
        // Something important like, flush to database
    }
    
    static void C() {
        Console.WriteLine("C Starts");
        B();        
        Console.WriteLine("C Ends");
    }

    static void D() {
        Console.WriteLine("D Starts");
        C();        
        Console.WriteLine("D Ends");
    }

    static void Main(string[] args)
    {

    
        // Console.WriteLine(Math.Log10(0));
        // Console.WriteLine(Math.Log10(1));
        // Console.WriteLine(Math.Log10(5));
        // Console.WriteLine(Math.Log10(9));
        // Console.WriteLine(Math.Log10(15));
        // Console.WriteLine(Math.Log10(20));
        // Console.WriteLine(Math.Log10(50));
        // Console.WriteLine(Math.Log10(100));
        // Console.WriteLine(Math.Log10(300));
        // Console.WriteLine(Math.Log10(2000));
        // Console.WriteLine(Math.Log10(30000));
    
        Console.WriteLine("MainStarts");
        try {
            D();
            
        } catch(Exception e) {
            Console.WriteLine(e.StackTrace);
        }
        
        Console.WriteLine("MainEnds");
    }
}
