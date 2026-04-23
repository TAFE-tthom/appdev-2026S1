namespace demo3;

public class Person {

    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name)
    {
        Name = name;
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public Person Clone() {
        Person p = new Person(Name, Age);
        return p;
    }
}

class Program
{
    static void PrintPeople(Person[] people)
    {
        for(int i = 0; i < people.Length; i++)
        {
            Console.Write(people[i].Name + ", ");
        }
        Console.WriteLine();
    }

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

        // // Aliasing - Case 1
        // //
        // //    [ 1, 2, 3, 4 ]
        // //       ^      ^
        // //      /        \
        // // nums1        nums2
        // //
        // // 
        // int[] numbers1 = { 1, 2, 3, 4 }; // 0x1000
        // int[] numbers2 = numbers1; // numbers2 gets assigned
        //                             // to the same address

        // Console.WriteLine("State 1");
        // PrintNumbers(numbers1);
        // PrintNumbers(numbers2);

        // numbers1[1] = 200;

        
        // Console.WriteLine("State 2");
        // PrintNumbers(numbers1);
        // PrintNumbers(numbers2);

    
        // // (No)Aliasing - Case 2
        // //        0x1000            0x2000
        // //    [ 1, 200, 3, 4 ]  [1, 2, 3, 4]
        // //       ^               ^
        // //      /               /
        // // nums1            nums2
        // //
        // //
        // numbers2 = new int[] { 1, 2, 3, 4 }; //0x2000

        // Console.WriteLine("\nState 3");
        // PrintNumbers(numbers1);
        // PrintNumbers(numbers2);

        // numbers1[2] = 200;

        
        // Console.WriteLine("State 4");
        // PrintNumbers(numbers1);
        // PrintNumbers(numbers2);
        
        // // Keeping Memory Alive - Case 3
        // //       0x3000(New)  0x1000 (Alive)   0x2000
        // //     [1, 2, 3]   [ 1, 200, 200, 4 ]  [1, 2, 3, 4]
        // //       ^               ^               Deleted
        // //      /               /
        // // nums1            nums2
        // //
        // //

        // numbers2 = numbers1;

        // numbers1 = new int[] { 1, 2, 3, 4 };

        // Console.WriteLine("\nState 5");
        // PrintNumbers(numbers1);
        // PrintNumbers(numbers2);

        // numbers1[2] = 200;

        
        // Console.WriteLine("State 6");
        // PrintNumbers(numbers1);
        // PrintNumbers(numbers2);

        
        // No-Aliasing with values but beware of value types - Case 4
        //
        //    [ 1, 2, 3, 4 ]   [ nums[0], nums[1], 30, 40 ]
        //       ^              ^
        //      /             /
        // nums1            nums2
        //
        // 
        // numbers1 = new int[]{ 1, 2, 3, 4 }; // 0x1000
        // numbers2 = new int[]{ numbers1[0], numbers1[1], 3, 4};

        // Console.WriteLine("\nState 7");
        // PrintNumbers(numbers1);
        // PrintNumbers(numbers2);

        // numbers1[1] = 200;

        
        // Console.WriteLine("State 8");
        // PrintNumbers(numbers1);
        // PrintNumbers(numbers2);

        // Aliasing with Reference Types - Case 5
        //
        //   Person p1 = new Person("Jeff");
        //   Person p2 = new Person("Alice");
        // 
        //    [ p1, p2, new Person("Bob") ]   [ new Person("Jan"), p2, people1[2] ]
        //       ^                             ^
        //      /                            /
        // people1                       people2
        //
        //

        Person p1 = new Person("Jeff");
        Person p2 = new Person("Alice");

        // Person[] people1 = new Person[] { p1, p2, new Person("Bob") };
        // Person[] people2 = new Person[] { new Person("Jan"), new Person(people1[1].Name), people1[2] };
        Person[] people1 = new Person[] { p1, p2, new Person("Bob") };
        Person[] people2 = new Person[] { new Person("Jan"), people1[0].Clone(), people1[2].Clone() };


        Console.WriteLine("\nState 9");
        PrintPeople(people1);
        PrintPeople(people2);

        people1[0].Name = "Jeffrey";
        
        
        Console.WriteLine("\nState 10");
        PrintPeople(people1);
        PrintPeople(people2);
        
    }
}
