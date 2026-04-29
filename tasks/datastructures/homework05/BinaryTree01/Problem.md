# Binary Trees

Your task is to implement a binary tree that will contain both a key and a value for each of its entries. A requirement for the tree is to ensure that a comparator function can be given to it.


```csharp

public class BinaryTreeMap<K, V> {

  private comparator: ObjectComparator<K>;

  public BinaryTreeMap(comparator: Func<bool, K, K>) {
    this.comparator = comparator;
  }

  // Rest of the methods to implement
  
}
  
```

Your binary tree should implement the following methods:

* `void Insert(key: K, value: V)` - Inserts a key and value pair into the binary tree.

* `V? Get(key: K)` - Gets a value based on the key given, if the key does not exist, then null is returned.

* `V? Remove(key: K)` - Gets the value based on the key, removes it from the tree and return it, if the key does not exist, it will return null.


## How To Test

You can test your solution by running `dotnet test`. This will test your solution to the test cases that are present.
