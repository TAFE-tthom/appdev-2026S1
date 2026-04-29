
# CSV Iterator

Your task is to construct a CSV Iterator. Similar to the line iterator, this will involve detecting new-lines characters as well as commas ',' that break apart the different words.

You will need to implement the following:

* `CSVEnumerator(string csvData)`, The constructor will accept the csv data as a large string.

* `bool HasNext()`, specifies if there is data still left to read or not.

* `string? GetNext()`, Method will return an individual cell entry in a csv file. When there is no more data left to consume, `done` will be set to `true`.

* `string? CurrentValue()`, Method will return the current cell that the iterator is currently on.

In addition, task yourself to adapt the current implementation to
implement iterator for this task. It will require you to implement IEnumerable and IEnumerator for a separate class or for CSVEnumerator itself.


## How to test

You can test your implementation with `dotnet test`, make sure you have the dependencies installed before running the test cases with `dotnet build`.
