namespace genericsexample02;

public interface LockableItem<T> {

    public string Name();

    public T? Replace(T? obj);

    public T? Remove();

    public bool Removed();
}

public class Item : LockableItem<Item> {

    private string name;
    private bool removed = false;

    public Item(string name) {
        this.name = name;
    }
    
    public string Name() {
        return name;
    }

    public Item? Replace(Item? obj) {
        // Item result = null; // Invalid -- ? indicate nullable
        if(!this.removed && obj != null) {
            string tempName = this.Name();
            this.name = obj.Name();
            obj.name = tempName;
            
            this.removed = false;
            obj.removed = true;
        } else if(obj != null) {
            this.name = obj.Name();
            this.removed = false;

            obj.name = string.Empty;
            obj.removed = true;
        } 
        return this;
    }

    public Item? Remove() {
        Item? result = this;
        if(this.removed) {
            
           result = null; 
        }
        this.removed = true;
        return result;
    }

    public bool Removed() {
        return this.removed;
    }
}


// 1.
// Locker<T> : LockableItem<T> - Locker is a LockableItem
// T is not
//
// 2.
// Locker<T> where T : LockableItem<T>
// T is a LockableItem

class Locker<T> where T : LockableItem<T> {

    private T[]? data = default(T[]);    
    private int capacity = 0;

    public Locker(int capacity, Func<T> initCallback) {
        this.capacity = capacity;
        this.data = new T[capacity];

        for(int i = 0; i < capacity; i++) {
            this.data[i] = initCallback();
        }
    }

    
    public T? Replace(T item, int index) {
        return item.Replace(data[index]);
    }
    public T? Remove(int index) {
        return data[index].Remove();
    }

    public bool IsRemoved(int index) {
        return data[index].Removed();
    }
    
}

class Program
{
    static void Main(string[] args)
    {
        Locker<string> locker = new Locker<string>(6,
            () => { return string.Empty; }
        );
        
        Locker<Item> locker = new Locker<Item>(6,
            () => { return new Item(string.Empty); }
        );

        Item racket = new Item("Tennis Racket");
        Item ball = new Item("Tennis Ball");

        Item book = new Item("Book");
        Item pencil = new Item("Pencil");

        Item result = locker.Replace(book, 2);
        Console.WriteLine(result.Name());

        result = locker.Replace(pencil, 2);
        Console.WriteLine(result.Name());
        
        result = locker.Replace(racket, 2);
        Console.WriteLine(result.Name());
    }
}
