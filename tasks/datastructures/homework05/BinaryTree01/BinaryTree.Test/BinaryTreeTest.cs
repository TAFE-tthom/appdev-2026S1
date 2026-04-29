namespace BinaryTree.Test;

public interface TestEval<K, V> {


    public void Evaluate(BinaryTree<K, V> tree);
    
}

public class TestItem<K, V> {
    public K Key { get; set; }
    public V Value { get; set; }

    public TestItem(K key, V value) {
        Key = key;
        Value = value;
    }
    
}

public class TestEvalItem<K, V> : TestItem<K, V>, TestEval<K, V>  {

    public K? KeyEval { get; set; }
    public V? ValueEval { get; set; }
    public Action<TestEvalItem<K, V>, BinaryTree<K, V>> Operation { get; set; }

    public TestEvalItem(K key, V value, K? keyEval, V? valueEval,
        Action<TestEvalItem<K, V>, BinaryTree<K, V>> operation) : base(key, value)
    {
        this.KeyEval = keyEval;
        this.ValueEval = valueEval;
        this.Operation = operation;
    }

    public void Evaluate(BinaryTree<K, V> tree) {
        this.Operation(this, tree);
    }

    public TestItem<K, V> ToItem() {
        return this;
    }
}


public class BinaryTreeTestSuite
{

    public static void StringIntCheck(TestEvalItem<string, int> titem,
        BinaryTree<string, int> tree) {

        var result = tree.Get(titem.Key);
        Assert.Equal(titem.ValueEval, result);
    }
    
    public static void IntStringCheck(TestEvalItem<int, string> titem,
        BinaryTree<int, string> tree) {

        var result = tree.Get(titem.Key);
        Assert.Equal(titem.ValueEval, result);
    }

    // public static void Check<T>(T actual, T expected)
    // {
    //     Assert.Equal(expected, a);
    // }

    public static void ToCheck<K, V>(BinaryTree<K, V> tree,
        List<TestEvalItem<K, V>> items)
    {
        foreach(var evalitem in items)
        {
            evalitem.Evaluate(tree);            
        }
    }

    private static void FillWith<K, V>(BinaryTree<K, V> bt,
        List<TestItem<K, V>> items) {
        foreach(var item in items) {
            bt.Insert(item.Key, item.Value);
        }
    }

    private static void RemoveItems<K, V>(BinaryTree<K, V> bt,
        List<TestItem<K, V>> items) {
        foreach(var item in items) {
            bt.Remove(item.Key);
        }
    }

    [Fact]
    public void Test_BinaryTree_Construction()
    {
        BinaryTree<int, int> tree = new(BinaryTreeExampleComparators.IntComparator);
        // Assume no exception or error occurs
        
    }

    [Fact]
    public void Test_BinaryTree_Insert_WithGet_1()
    {
        BinaryTree<int, string> tree = new(BinaryTreeExampleComparators
            .IntComparator);

        Action<TestEvalItem<int, string>, BinaryTree<int, string>> actionCheck =
            (a, b) => { IntStringCheck(a, b); };

        var items = new TestEvalItem<int, string>[] {
                new TestEvalItem<int, string>(20, "20", 20, "20", actionCheck),
            };

        FillWith(tree, items.Select((a) => a.ToItem()).ToList());
        ToCheck(tree, items.ToList());
    }

    [Fact]
    public void Test_BinaryTree_Insert_WithGet_3()
    {
        BinaryTree<int, string> tree = new(BinaryTreeExampleComparators
            .IntComparator);

        Action<TestEvalItem<int, string>, BinaryTree<int, string>> actionCheck =
            (a, b) => { IntStringCheck(a, b); };

        var items = new TestEvalItem<int, string>[] {
                new(20, "20", 20, "20", actionCheck),
                new(30, "30", 30, "30", actionCheck),
                new(10, "10", 10, "10", actionCheck),
            };

        FillWith(tree, items.Select((a) => a.ToItem()).ToList());
        ToCheck(tree, items.ToList());
    }
    
    [Fact]
    public void Test_BinaryTree_Insert_WithGet_4()
    {
        BinaryTree<int, string> tree = new(BinaryTreeExampleComparators
            .IntComparator);

        Action<TestEvalItem<int, string>, BinaryTree<int, string>> actionCheck =
            (a, b) => { IntStringCheck(a, b); };

        var items = new TestEvalItem<int, string>[] {
                new(20, "20", 20, "20", actionCheck),
                new(30, "30", 30, "30", actionCheck),
                new(10, "10", 10, "10", actionCheck),
                new(50, "50", 50, "50", actionCheck),
            };

        FillWith(tree, items.Select((a) => a.ToItem()).ToList());
        ToCheck(tree, items.ToList());
    }
    
    [Fact]
    public void Test_BinaryTree_Insert_WithGet_10()
    {
        BinaryTree<int, string> tree = new(BinaryTreeExampleComparators
            .IntComparator);

        Action<TestEvalItem<int, string>, BinaryTree<int, string>> actionCheck =
            (a, b) => { IntStringCheck(a, b); };

        var items = new TestEvalItem<int, string>[] {
                new(20, "20", 20, "20", actionCheck),
                new(30, "30", 30, "30", actionCheck),
                new(10, "10", 10, "10", actionCheck),
                new(50, "50", 50, "50", actionCheck),
                new(80, "80", 80, "80", actionCheck),
                new(100, "100", 100, "100", actionCheck),
                new(5, "5", 5, "5", actionCheck),
                new(1, "1", 1, "1", actionCheck),
                new(8, "8", 8, "8", actionCheck),
                new(7, "7", 7, "7", actionCheck),
            };

        FillWith(tree, items.Select((a) => a.ToItem()).ToList());
        ToCheck(tree, items.ToList());
    }
    
    [Fact]
    public void Test_BinaryTree_Insert_NowRemove_Root_1()
    {
        BinaryTree<int, string> tree = new(BinaryTreeExampleComparators
            .IntComparator);

        Action<TestEvalItem<int, string>, BinaryTree<int, string>> actionCheck =
            (a, b) => { IntStringCheck(a, b); };

        var items = new TestEvalItem<int, string>[] {
                new(20, "20", 20, "20", actionCheck),
                new(30, "30", 30, "30", actionCheck),
                new(10, "10", 10, "10", actionCheck),
                new(50, "50", 50, "50", actionCheck),
                new(80, "80", 80, "80", actionCheck),
                new(100, "100", 100, "100", actionCheck),
                new(5, "5", 5, "5", actionCheck),
                new(1, "1", 1, "1", actionCheck),
                new(8, "8", 8, "8", actionCheck),
                new(7, "7", 7, "7", actionCheck),
            };

        FillWith(tree, items.Select((a) => a.ToItem()).ToList());
        RemoveItems(tree, items.Where(a => a.Key == 20).Select(a => a.ToItem()).ToList());
        ToCheck(tree, items.Skip(1).Select(a => a).ToList());
    }
    
    [Fact]
    public void Test_BinaryTree_Insert_NowRemove_Root_Left()
    {
        BinaryTree<int, string> tree = new(BinaryTreeExampleComparators
            .IntComparator);

        Action<TestEvalItem<int, string>, BinaryTree<int, string>> actionCheck =
            (a, b) => { IntStringCheck(a, b); };

        var items = new TestEvalItem<int, string>[] {
                new(20, "20", 20, "20", actionCheck),
                new(30, "30", 30, "30", actionCheck),
                new(10, "10", 10, "10", actionCheck),
                new(50, "50", 50, "50", actionCheck),
                new(80, "80", 80, "80", actionCheck),
                new(100, "100", 100, "100", actionCheck),
                new(5, "5", 5, "5", actionCheck),
                new(1, "1", 1, "1", actionCheck),
                new(8, "8", 8, "8", actionCheck),
                new(7, "7", 7, "7", actionCheck),
            };

        FillWith(tree, items.Select((a) => a.ToItem()).ToList());
        RemoveItems(tree, items.Where(a => a.Key == 10).Select(a => a.ToItem()).ToList());
        ToCheck(tree, items.Where(a => a.Key != 10).ToList());
    }
    
    [Fact]
    public void Test_BinaryTree_Insert_NowRemove_Root_Right()
    {
        BinaryTree<int, string> tree = new(BinaryTreeExampleComparators
            .IntComparator);

        Action<TestEvalItem<int, string>, BinaryTree<int, string>> actionCheck =
            (a, b) => { IntStringCheck(a, b); };

        var items = new TestEvalItem<int, string>[] {
                new(20, "20", 20, "20", actionCheck),
                new(30, "30", 30, "30", actionCheck),
                new(10, "10", 10, "10", actionCheck),
                new(50, "50", 50, "50", actionCheck),
                new(80, "80", 80, "80", actionCheck),
                new(100, "100", 100, "100", actionCheck),
                new(5, "5", 5, "5", actionCheck),
                new(1, "1", 1, "1", actionCheck),
                new(8, "8", 8, "8", actionCheck),
                new(7, "7", 7, "7", actionCheck),
            };

        FillWith(tree, items.Select((a) => a.ToItem()).ToList());
        RemoveItems(tree, items.Where(a => a.Key == 30).Select(a => a.ToItem()).ToList());
        ToCheck(tree, items.Where(a => a.Key != 30).ToList());
    }
}
