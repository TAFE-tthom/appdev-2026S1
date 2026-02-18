
# Sliding Window

You have been tasked with writing a class that will operate as a sliding window for an array. A sliding window in the context is a way of treating an array as view.

Lets assume we have an array of size 8 and defined as below:

```cs 
int[] numbers = [ 1, 2, 3, 4, 5, 6, 7, 8 ];
```

With the `SlidingWindow` class, it will need to accept the the array as part of its construction and also a size and offset.

```cs

SlidingWindow wd = new SlidingWindow(numbers, 2, 4);
```

The snippet above shows the sliding window starting at position 2 and of length 4.

If we were to diplay or retrieve the contents using the `SlidingWindow`, we would get `[3, 4, 5, 6]`.

We can also adjust the position as well, lets consider the following case where we adjust the offset to 4. It will display the contents `[5, 6, 7, 8]`


You will need to implement the following:

* `SlidingWindow(int[] array, int offset, int length)` - The initialisation of the `SlidingWindow` object.

* `setOffset(int offset)` - Updates the offset value

* `getElement(int index)` - Gets an element from the array based on `offset + index`.

* `setElement(int value, int index)` - Sets an element based on `offset + index`.


## How to test

You can test your implementation using `dotnet test`. It will check your solution against the set of test cases that have been bundled.




