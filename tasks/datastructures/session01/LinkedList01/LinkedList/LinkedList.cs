namespace LinkedList;

public class LinkedListNode
{

    public LinkedListNode? Next { get; set; }
    public int Value { get; set; }

    public LinkedListNode(int value) {
        Next = null;
        Value = value;
    }

}

public class LinkedList
{


    public int Size { get; private set; }

    public LinkedList() {

    }


    public void Append(int item) {

    }

    public void Prepend(int item) {

    }


    public int? Get(int index) {

        return null;
    }

    public int? Remove(int index) {

        return null;
    }


}
