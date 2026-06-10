namespace Demo1;

public class NodeObject {

    public string Tag { get; set; }
    public List<NodeObject?> Connections { get; set; } =
        new List<NodeObject>();

    public NodeObject(string tag) {
        Tag = tag;
    }

    public void AddConnection(NodeObject other) {
        other.Connections.Add(this);
        Connections.Add(other);
    }
}


class Program
{
    static void Main(string[] args)
    {
        NodeObject A = new NodeObject("A");
        NodeObject B = new NodeObject("B");
        NodeObject C = new NodeObject("C");

        A.AddConnection(B);
        A.AddConnection(C);
        B.AddConnection(C);

        NodeObject cursor = A;

        Console.WriteLine(cursor.Tag);

        cursor = cursor.Connections[1];
        
        Console.WriteLine(cursor.Tag);
        
        cursor = cursor.Connections[1];
        
        Console.WriteLine(cursor.Tag);
    }
}
