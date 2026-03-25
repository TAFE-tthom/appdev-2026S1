# Circular Buffer

You are tasked with constructing a circular buffer. A Circular Buffer is a kind of
data structure that will use an array but maintain a size and index property to
know how many elements are in the buffer and what the current position is.

How does this work?

```

Lets say for a Circular Buffer we have a capacity of size 4.

| X | X | X | X |

This would mean we have an index of 0 and size of 0.

-> When we add an element to the buffer it will change:

| 1 | X | X | X |

.add(1)

This means that the size has changed to 1 but index is still 0.

Lets add two more elements:

.add(2)
.add(45)

| 1 | 2 | 45 | X |


index is 0, size is 3
             idx = 3
| 70 | X | X | 6 |
So when we remove or `dequeue`, we will be removing from where the
index is currently located.

Just before:

 idx = 0
| 1 | 2 | 45 | X |

     idx = 1
| X | 2 | 45 | X |


index is now 1, size is 2

What has happened is that we used the current index, retrieved
the element and then updated the index by 1.

Lets skip ahead to the following situation

             idx = 3
| X | X | X | 6 |


We have two things we can do:

.add
or
.dequeue

If we add, given that size is 1, we need to find a new spot for it

We can do this by using the modulus operator and wrap around using
the capacity of the array.

.add(70) will result in:

             idx = 3
| 70 | X | X | 6 |

Where size is now 2 and index is still 3.


Now, if we were to dequeue, we would need to apply a similar idea but update
the index.

So, when we call:

.dequeue() we will see the following:

Before:

             idx = 3
| 70 | X | X | 6 |

After:

 idx = 0
| 70 | X | X | X |

Which results in index of 0, size of 1, since the index would have
become 4, which is outside of the bounds of the array, we needed to wrap it around

We can express this nicely via index = (index + 1) % capacity;

If capacity is 4 and (index + 1) is 4, this results in 0.

```

## How to test?

You can test your implementation by running `dotnet test` with a suite of test cases
associated with the solution.
