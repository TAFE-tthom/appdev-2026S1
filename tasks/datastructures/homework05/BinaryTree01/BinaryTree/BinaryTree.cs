namespace BinaryTree;


public class BinaryTreeExampleComparators {

	public static int IntComparator(int a, int b)
	{
		return a - b;
	}


	public static int StringComparator(string a, string b)
	{
		return a.CompareTo(b);	
	}
	
}


public class BinaryTreeNode<K, V>
{
	public K Key { get; set; }
	public V Value { get; set; }

	public BinaryTreeNode(K key, V value)
	{
		this.Key = key;
		this.Value = value;
	}
}


public class BinaryTree<K, V>
{

	private Func<K, K, int> comparator;

	public BinaryTree(Func<K, K, int> comparator)
	{
		this.comparator = comparator;
	
	}


	public void Insert(K key, V value)
	{
		
	}


	public V? Get(K key)
	{

		return default(V);
	}


	public V? Remove(K key)
	{

		return default(V);
	}


	public int Size()
	{

		return 0;
	}



}
