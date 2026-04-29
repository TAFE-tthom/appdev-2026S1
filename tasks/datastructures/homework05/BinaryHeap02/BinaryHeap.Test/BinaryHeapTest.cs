namespace BinaryHeap.Test;


public class BinaryHeapTestSuite
{

    [Fact]
    public void Test_BinaryHeapConstruction()
    {
        BinaryHeap heap = new BinaryHeap();
    }

    
    [Fact]
    public void Test_BinaryHeap_Empty()
    {
        
        BinaryHeap heap = new BinaryHeap();
        var item = heap.RemoveMin();

        Assert.Null(item);
    }
    
    [Fact]
    public void Test_BinaryHeap_Many()
    {
        BinaryHeap heap = new BinaryHeap();

        int[] input = [
            10,
            5,
            20,
            4,
            9,
            2,
            8,
            1,
            44,
            43
        ];

        int[] expected = [
             1, 2, 4, 5, 8, 9, 10, 20, 43, 44
        ];
        
        foreach(var item in input) {
            heap.Insert(item);
        }

        for(int i = 0; i < expected.Length; i++) {
            var expectedItem = expected[i];
            var actualItem = heap.RemoveMin();
            Assert.Equal(expectedItem, actualItem);
        }
    }
    
    [Fact]
    public void Test_BinaryHeap_Two()
    {
        BinaryHeap heap = new BinaryHeap();

        int[] input = [
            20,
            4
        ];

        int[] expected = [
            4, 20
        ];
        
        foreach(var item in input) {
            heap.Insert(item);
        }

        for(int i = 0; i < expected.Length; i++) {
            var expectedItem = expected[i];
            var actualItem = heap.RemoveMin();
            Assert.Equal(expectedItem, actualItem);
        }

    }
    
    [Fact]
    public void Test_BinaryHeap_Four()
    {
        BinaryHeap heap = new BinaryHeap();

        int[] input = [
            10,
            5,
            20,
            4
        ];

        int[] expected = [
            4, 5, 10, 20
        ];
        
        foreach(var item in input) {
            heap.Insert(item);
        }

        for(int i = 0; i < expected.Length; i++) {
            var expectedItem = expected[i];
            var actualItem = heap.RemoveMin();
            Assert.Equal(expectedItem, actualItem);
        }

    }
    
    [Fact]
    public void Test_BinaryHeap_One()
    {
        BinaryHeap heap = new BinaryHeap();
        heap.Insert(10);

        var actual = heap.RemoveMin();

        Assert.Equal(10, actual);

    }
}
