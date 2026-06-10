namespace Demo1;

public class GraphNodeConnection {

    public GraphNode Node { get; set; }
    public int Weight { get; set; }

    public GraphNodeConnection(GraphNode node, int weight) {
        Node = node;
        Weight = weight;
    }
    
}

public class GraphNode {

    public string Name { get; set; }
    public List<GraphNodeConnection> Connections { get; set; } // References, doesn't own

    public GraphNode(string name) {
        Name = name;
        Connections = new List<GraphNodeConnection>();
    }

    public void AddConnection(GraphNode node, int weight) {
        Connections.Add(new GraphNodeConnection(node, weight));
    }

    public GraphNodeConnection? GetConnection(int index) {
        if(index < 0 || index >= Connections.Count()) {
            return null;
        } else {
            return Connections[index];
        }
    }
    
}


public class Graph {

    public List<GraphNode> Nodes { get; set; } // Graph actually owns the nodes

    public Graph() {
        
        Nodes = new List<GraphNode>();
    }

    public void AddNode(GraphNode node) {
        Nodes.Add(node);
    }

    public GraphNode? GetNode(int index) {
        if(index < 0 || index >= Nodes.Count()) {
            return null;
        } else {
            return Nodes[index];
        }
    }
    
}

public class QueueEntry {
    public GraphNode Node { get; set; }
    public int Level { get; set; }
    public int Weight { get; set; }

    public QueueEntry(GraphNode node, int level, int weight) {
        Node = node;
        Level = level;
        Weight = weight;
    }

    public override string ToString() {
        return Level + ": " + Node.Name + " : " + Weight;
    }
}


/// How we can generalise the graph operation
public class GraphIterator<T> {

    private object container = null;
    private Func<T> getNextNode = null;
    private Action<T> addNode = null;
    private Func<bool> isEmptyFn = null;

    public GraphIterator(
        object container,
        Func<T> getNextFn,
        Action<T> addNodeFn,
        Func<bool> isEmptyFn) {
        
        this.container = container;
        this.getNextNode = getNextFn;
        this.addNode = addNodeFn;
        this.isEmptyFn = isEmptyFn;
    }

    public T? Next() {

        var result = this.getNextNode();
        Console.WriteLine("Next: " + result.ToString());
        return result;
    }

    public bool Finished() {

        return this.isEmptyFn();
    }

    public void Add(T node) {
        this.addNode(node);
    }
    
    
}

class Program
{
    public static void GraphOperation(Graph graph,
        int startNodeIndex,
        int endDestination,
        GraphIterator<QueueEntry> queue) {

        // HashSet<string> visited = new HashSet<string>();
        GraphNode start = graph.GetNode(startNodeIndex);
        string destinationTag = graph.GetNode(endDestination).Name;
        int minWeight = Int32.MaxValue;
        
        queue.Add(new QueueEntry(start, 0, 0));
        // visited.Add(start.Name);

        while(!queue.Finished()) {
            var current = queue.Next();
            
            for(int i = 0; i < current.Node.Connections.Count(); i++) {
                var neighbour = current.Node.Connections[i];
                // var visitedValue = string.Empty;
                // var exists = visited.TryGetValue(neighbour.Node.Name, out visitedValue);

                int level = current.Level + 1;
                int weight = current.Weight + neighbour.Weight;

                
                if(destinationTag == neighbour.Node.Name && weight < minWeight) {
                    minWeight = weight;
                }
                
                queue.Add(new QueueEntry(neighbour.Node, level, weight));
            }
        }
        Console.WriteLine("ShortestPath Cost: " + minWeight);        
    }

    static void Main(string[] args)
    {
        Graph graph = new Graph();

        GraphNode a = new GraphNode("A");
        GraphNode b = new GraphNode("B");
        GraphNode c = new GraphNode("C");
        GraphNode d = new GraphNode("D");
        GraphNode e = new GraphNode("E");
        GraphNode f = new GraphNode("F");
        GraphNode g = new GraphNode("G");
        GraphNode h = new GraphNode("H");
        GraphNode i = new GraphNode("I");
        GraphNode j = new GraphNode("J");


        graph.AddNode(a);
        graph.AddNode(b);
        graph.AddNode(c);
        graph.AddNode(d);
        graph.AddNode(e);
        graph.AddNode(f);
        graph.AddNode(g);
        graph.AddNode(h);
        graph.AddNode(i);
        graph.AddNode(j);

        a.AddConnection(b, 6);
        a.AddConnection(c, 2);
        a.AddConnection(e, 3);

        
        b.AddConnection(f, 1);

        c.AddConnection(d, 2);
        
        e.AddConnection(h, 4);

        f.AddConnection(g, 1);
        
        d.AddConnection(i, 8);

        
        h.AddConnection(j, 4);

        
        g.AddConnection(j, 1);
        
        i.AddConnection(j, 1);

        //A --> J, detect when we finish

        // Queue<QueueEntry> queue = new Queue<QueueEntry>();
        // Stack<QueueEntry> queue = new Stack<QueueEntry>();
        PriorityQueue<QueueEntry, int> queue = new PriorityQueue<QueueEntry, int>();
        
        GraphIterator<QueueEntry> iter = new GraphIterator<QueueEntry>(
            queue,
            () => { return queue.Dequeue(); },
            (entry) => { queue.Enqueue(entry, entry.Weight); },
            () => { return queue.Count == 0; }
        );
        
        GraphOperation(graph, 0, 9, iter); // Graph and A for starting point
    
    }
}
