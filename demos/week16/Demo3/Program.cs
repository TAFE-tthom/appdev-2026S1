namespace Demo3;

class Program
{

    public static void PrintEmployee(Employee e) {
        e.Print();
    }

    static void Main(string[] args)
    {
        Employee e = new Employee(1, "Tom", "Fred");
        Teacher t = new Teacher(2, "Thomas", "Davidson", 1, "Teacher");
        PrintEmployee(t.Employee); // PrintEmployee(t);
    }
}

public class Employee {
    public int employeeId;
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public static int NumberOfEmployees = 0;

    private Action<Employee, string> doWork = (Employee e, string job) => {
        Console.WriteLine("Working on: " + job);
    };
    
    public Action<Employee> print = (Employee e) => {
        Console.WriteLine(e.employeeId + " : "
            + e.FirstName
            + " "
            + e.LastName);
    };

    public Employee(int employeeId, string first, string last)
    {
        this.employeeId = employeeId;
        this.FirstName = first;
        this.LastName = last;
        Employee.NumberOfEmployees += 1;
    }

    public void DoWork(string job)
    {
        doWork(this, job);
    }

    public void Print()
    {
        print(this);
    }

    public void SetPrint(Action<Employee> action) {
        this.print = action;
    }
    
}

public class Teacher {

    public Employee Employee { get; private set; }
    public int teacherId;
    public string specialisation; 

    public Teacher(int employeeId, string first, string last,
        int teacherId, string specialisation)
    {
        Employee = new Employee(employeeId, first, last);
        var oldPrint = Employee.print;

        Employee.SetPrint((e) => {
            oldPrint(e);
            Console.WriteLine("Occupation : Teacher");
        });
        
        
        this.teacherId = teacherId;
        this.specialisation = specialisation;
    }

    
}

// class Program
// {

//     static Employee GetEmployeeByIndex(Employee[] employees, int id) {
//         int index = id-1;
//         if(index < 0 || index >= employees.Length)
//         {
//             return null;
//         }
//         return employees[index];
//     }

//     static void Main(string[] args)
//     {
//         Employee imp1 = new Employee(1, "Minion 1", "Minion");
//         Employee imp2 = new Employee(2, "Minion 2", "Minion");
//         Employee imp3 = imp2; // new implies Allocation

//         Employee teach1 = new Teacher(3, "TeacherMinion 1", "Minion",
//             1, "Programming");

        

//         imp1.Print();
//         imp2.Print();
//         teach1.Print();

//         Console.WriteLine(Employee.NumberOfEmployees);

//         // teach1.DoWork("I'm teaching here!");
    
//     }
// }
