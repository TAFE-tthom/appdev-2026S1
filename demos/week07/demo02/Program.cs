namespace demo02;

public class StatementData {
    public string Name { get; set; }
    public bool IsRaining { get; set; }

    public StatementData(string name, bool isRaining) {
        Name = name;
        IsRaining = isRaining;
    }
}

interface Statement {
    string Make(StatementData data);
}


class Hello : Statement {
    public string Make(StatementData data) {
        string name = data.Name;
        return "Hello, " + name + "! how are you today?";
    }
}

class GoodBye : Statement {
    public string Make(StatementData data) {
        if(data.IsRaining) {
            return "I should get out of the rain! "
                + "Catch you next time!";
        } else {
            return "Well it is getting late! See you next time!";
        }
    
    }
}

class GoodEvening : Statement {
    public string Make(StatementData data) {
        return "Actually, I should have said good evening!"; }
}


class Program
{
    static void Main(string[] args)
    {
        StatementData data = new StatementData("Jeff", true);
        Statement[] statements = new Statement[] {
            new Hello(),
            new GoodEvening(),
            new GoodBye(),
            new GoodBye()
        };

        for(int i = 0; i < statements.Length; i++) {
            string msg = statements[i].Make(data);
            if(i == 2) {
                data.IsRaining = false;
            }
            Console.WriteLine(msg);
        }
    
    }
}
