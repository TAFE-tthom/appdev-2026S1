# Dynamic Array

And we're back to building more data-structures! This time, we are building
a dynamic array. You have seen this data type before, as you have used
something like `List` or `ArrayList`.

A dynamic array will have the following methods and properties associated 
and you will need to implement each one and also support `Generics` 
with your implementation.


* `int Size` - Property that indicates the number of elements stored
    in the dynamic array.

* `int Capacity` - Property that indicates the current capacity of the
    internal array

* `void Append(T item)` - Adds the item to the next available position
    in the array. If the Array is at capacity, the array should be
    resized to a new capacity and the capacity doubled.

* `T? Get(int index)` - Retrieves an element within the array, if
    index is < 0 or >= Size, the data structure should throw a
    `IndexOutOfRangeException` exception.

* `T? Remove(int index)` - Removes an element within the array, if
    the index is < 0 or >= Size, the data structure should throw a
    `IndexOutOfRangeException`. Once the element has been removed
    the elements greater than the current index, should be shifted.

## How To Test

You can test your implementation against the suite of test cases
by running `dotnet test`.
