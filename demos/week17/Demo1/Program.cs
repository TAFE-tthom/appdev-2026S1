using System.Text;

namespace Demo1;


public class Task {
    public int Key { get; set; }
    public string Name { get; set; }
    public List<Employee> Employees { get; set; }
    public Task(int key, string name) {
        Key = key;
        Name = name;
        Employees = new();
    }

    
    public void PrintNameAndEmployees() {
        Console.WriteLine(Name + ":");
        for(int i=0; i < Employees.Count(); i++) {
            Console.WriteLine("\t " + Employees[i].Name);
        }
    }
}

// Employee.Where()

public class EmployeeQueryGenerationState
{
    private List<string> SQLComposition { get; set; }
    private EmployeeDescriptor descriptor = new();

    public EmployeeQueryGenerationState() {

        SQLComposition = new();
        SQLComposition.Add("SELECT " + descriptor.Key + ", " + descriptor.Name);
        SQLComposition.Add("FROM " + "Employee");
    }

    public EmployeeQueryGenerationState Where(string comparison) {
        string whereSql = "WHERE " + comparison;
        SQLComposition.Add(whereSql);
        return this;
    }

    public string First() {
        string limitSql = "LIMIT 1";
        SQLComposition.Add(limitSql);

        return BuildQuery();
    }
    public string Limit(int count) {
        string limitSql = "LIMIT " + count;
        SQLComposition.Add(limitSql);

        return BuildQuery();
    }

    public string All() {
        return BuildQuery();
    }

    private string BuildQuery() {
        StringBuilder bld = new StringBuilder();
        for(int i = 0; i < SQLComposition.Count()-1; i++) {
            bld.Append(SQLComposition[i] + "\n");
        }
        bld.Append(SQLComposition[SQLComposition.Count()-1]);
        return bld.ToString() + ";";
    }
}

public class EmployeeDescriptor {
    public string Key = "EmployeeId";
    public string Name = "FullName";
}

public class Employee {
    public int Key { get; set; }
    public string Name { get; set; }
    public List<Task> Tasks { get; set; }

    public Employee(int key, string name) {
        Name = name;
        Key = key;
        Tasks = new();
    }

    public void PrintNameAndTasks() {
        Console.WriteLine(Name + ":");
        for(int i=0; i < Tasks.Count(); i++) {
            Console.WriteLine("\t " + Tasks[i].Name);
        }
    }

    public static EmployeeQueryGenerationState Where(string comparison)
    {
        EmployeeQueryGenerationState state = new EmployeeQueryGenerationState();
        state.Where(comparison);

        return state;
    }
    
}

public class KeyMap {
    public int Key1 { get; set; }
    public int Key2 { get; set; }

    public KeyMap(int key1, int key2){
        Key1 = key1;
        Key2 = key2;
    }
}


class Program
{

    static void ResolvingLinks(List<Employee> employees, List<Task> tasks,
        List<KeyMap> keymap) {

        for(int i = 0; i < keymap.Count(); i++) {
            KeyMap map = keymap[i];
            Employee emp = employees[map.Key1];
            Task task = tasks[map.Key2];

            emp.Tasks.Add(task);
            task.Employees.Add(emp);
            
        }
        
    }    

    static void Main(string[] args)
    {
        Employee[] employees = new Employee[] {
            new Employee(0, "Jeff"),
            new Employee(1, "Alice"),
            new Employee(2, "Bob"),
        };
            
        Task[] tasks = new Task[] {
            
            new Task(0, "Programming in C#"),
            new Task(1, "Programming in JS"),
            new Task(2, "Programming in SQL"),
            new Task(3, "Learning about ORMs"),
        };
        
        KeyMap[] keyMap = new KeyMap[] {
            new KeyMap(0, 0),
            new KeyMap(1, 1),
            new KeyMap(1, 0),
            new KeyMap(2, 2),
            new KeyMap(2, 3),
        };

        ResolvingLinks(employees.ToList(),
            tasks.ToList(),
            keyMap.ToList());
        
        // Console.WriteLine("Printing Employees");
        
        // for(int i = 0; i < employees.Count(); i++) {
        //     employees[i].PrintNameAndTasks();
        // }

        // Console.WriteLine("\nPrinting Tasks");
        
        // for(int i = 0; i < tasks.Count(); i++) {
        //     tasks[i].PrintNameAndEmployees();
        // }

        string query = Employee
            .Where("EmployeeID < 10")
            .First();

        Console.WriteLine(query);
    }
}
