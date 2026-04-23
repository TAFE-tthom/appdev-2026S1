namespace linkedlist;

public class LinkedListNode {

    public int Value { get; set; }
    public LinkedListNode Next { get; set; } = null;

    public LinkedListNode(int value) {
        this.Value = value;
    }
    public LinkedListNode(int value, LinkedListNode nxt){
        this.Value = value;
        this.Next = nxt;
    }
}

public class LinkedList {
    public LinkedListNode First { get; set; } = null;
    public LinkedListNode Tail { get; set; } = null;

    public int? Get(int index) {
        LinkedListNode current = First;
        int counter = 0;
        int? result = null;
        while(current != null && counter < index) {

            counter++;
            current = current.Next;
        }
        
        if(current != null) {
            result = current.Value;
        }

        return result;
    }
    // Append (This is Enqueue)
    public void AppendOld(int value) {
        LinkedListNode newNode
            = new LinkedListNode(value);
        if(First == null) { // for a linked list / queue of 1
            First = newNode;
            Tail = newNode;
        } else { // for a linked list / queue of N
            LinkedListNode current = First;
            while(current.Next != null) {

                current = current.Next;
            }
            current.Next = newNode;
            Tail = newNode;
        }
        
    }

    // Append (This is Enqueue)
    public void Append(int value) {
        LinkedListNode newNode
            = new LinkedListNode(value);
        if(First == null) { // for a linked list / queue of 1
            First = newNode;
            Tail = newNode;
        } else { // for a linked list / queue of N
            if(First == Tail) { //First and Tail could be same
                // because linked list only has 1 element
                First.Next = newNode;
                Tail = newNode;
            } else {
                // for linked list / queue of N
                Tail.Next = newNode;
                Tail = newNode;
            }
            
        }
        
    }

    public int? Dequeue() {
        int? result = null;
        if(First != null) {
            LinkedListNode temp = First;
            First = First.Next;
            result = temp.Value;
        }
        return result;
    }

    public int? Remove(int index) {

        int? result = null;

        if(index == 0 && First != null) {
            LinkedListNode temp = First;
            First = First.Next;
            result = temp.Value;
        } else if(First != null) {
        
            LinkedListNode current = First.Next;
            LinkedListNode prev = First;
            int counter = 1;
            while(current != null && counter < index) {

                counter++;
                prev = current;
                current = current.Next;
            }

            //Remove and re-stitch
            if(current != null) {
                result = current.Value;
                prev.Next = current.Next;
            }
        }

        return result;
    }
    
}

class Program
{
    public static void Benchmark_AppendOld(int N) {
        LinkedList list = new LinkedList();
        for(int i = 0; i < N; i++) {
            list.AppendOld(i);
        }
    }

    public static void Benchmark_Append(int N) {
        LinkedList list = new LinkedList();
        for(int i = 0; i < N; i++) {
            list.Append(i);
        }
    }

    static void Main(string[] args) {

        Benchmark_AppendOld(100000);
        
    }

    // static void Main(string[] args)
    // {
    //     LinkedList list = new LinkedList();

    //     list.Append(10);
    //     list.Append(20);
    //     list.Append(30); // 30 should print
    //     list.Append(40);
    //     list.Append(50);

    //     list.Append(60);
    //     list.Append(70);

    //     // 10 -> 20 -> ... -> 50 -> 60 -> 70
    //     Console.WriteLine(list.Get(2));
    //     Console.WriteLine(list.Get(4));
    //     Console.WriteLine(list.Get(5));

    //     // list.Remove(5);
        

    //     // // 10 -> 20 -> ... -> 50 -> 70
    //     // Console.WriteLine(list.Get(2));
    //     // Console.WriteLine(list.Get(4));
    //     // Console.WriteLine(list.Get(5));
    // }
}
