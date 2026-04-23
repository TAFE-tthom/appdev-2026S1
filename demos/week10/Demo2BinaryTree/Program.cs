namespace Demo2;

class BinaryTreeNode {
    public int Key { get; set; }
    public string Value { get; set; }

    public BinaryTreeNode? Left { get; set; }
    public BinaryTreeNode? Right { get; set; }
    public BinaryTreeNode? Parent { get; set; }
    
    public BinaryTreeNode(int key, string value) {
        this.Key = key;
        this.Value = value;
        Left = null;
        Right = null;
        Parent = null;
    }
    
}


class BinaryTree {

    private BinaryTreeNode? root = null;

    public BinaryTree() {
        
    }

    private void InsertRecursive(BinaryTreeNode? node,
        BinaryTreeNode newNode)
    {
        if(node != null) {
            
            if(node.Key == newNode.Key) {
                node.Value = newNode.Value;
                
            } else if (newNode.Key < node.Key) {
                if(node.Left != null) {
                    InsertRecursive(node.Left, newNode);
                } else {
                    node.Left = newNode;
                }
                
                
            } else {
                if(node.Right != null) {
                    InsertRecursive(node.Right, newNode);
                } else {
                    node.Right = newNode;
                }
                
            }
            
        }
        
        
    }

    public void Insert(int key, string value) {
        BinaryTreeNode newNode = new BinaryTreeNode(key, value);
        
        
        if(root == null) {
            root = newNode;    
        } else {
            InsertRecursive(root, newNode);
        }
    }

    private BinaryTreeNode? GetEntry(BinaryTreeNode? node, int key)
    {
        if(node != null) {
            Console.Write(" -> " + node.Key + " GetKey(" + key + ")");
            if(node.Key == key) {
                return node;           
            } else if (key < node.Key) {
                return GetEntry(node.Left, key);
            } else {
                return GetEntry(node.Right, key);
            }
            
        } else {
            return null;
        }
        
    }

        


    public int? GetKey(int key) {
        BinaryTreeNode? node = GetEntry(root, key);
        if(node != null) {
            return node.Key;
        } else {
            return null;
        }
    }
    
    public string? GetValue(int key) {
    
        BinaryTreeNode node = GetEntry(root, key);
        if(node != null) {
            return node.Value;
        } else {
            return null;
        }
    }

    private void InOrderTraversal(BinaryTreeNode? node)
    {
        if(node.Left != null) {
            InOrderTraversal(node.Left);
        }
        Console.WriteLine(node.Key);
        if(node.Right != null) {
            InOrderTraversal(node.Right);
        }
    }

    public void InOrder() {
        InOrderTraversal(root);
    }
    
    
}


class Program
{
    static void Main(string[] args)
    {
        BinaryTree bt = new BinaryTree();

        //                2*i + 1 for left
        //                2*i + 2 for right
        //
        //  Insert(key=90)
        //                     1.  2*0 + 2 = 2
        //                     2.  2*2 + 2 = 6
        //  Insert(key=85)
        //                     1.  2*0 + 2 = 2
        //                     2.  2*2 + 2 = 6
        //                     3.  2*2 + 1 = 13
        // 
        //              0   1   2  3  4  5  6
        int[] demo = { 50, 30, 80, _, _, _, 90, _, _, _, _, _, _, 85,_ };

        //
        //             | 5 |
        // 1  2  3 | 4       6 | 7  8  9
        //
        // 
        // 

        int[] numbers = { 50, 30, 80, 90, 100, 10, 35, 40, 20 };
        

        string[] names = { "Fifty", "Thirty",
            "Eighty", "Ninety", "Hundred", "Ten", "Thirty-Five",
            "Fourty", "Twenty"
        };
        
        for(int i = 0; i < numbers.Length; i++) {
            bt.Insert(numbers[i], names[i]);
            
        }

        bt.InOrder();
        // // for(int i = 0; i < numbers.Length; i++) {
        //     int? result = bt.GetKey(numbers[i]);
        //     Console.WriteLine("\n-----");
        //     if(result != null) {
            
        //         // Console.WriteLine(result);
        //     } else {
        //         Console.WriteLine("Number should exist: ", numbers[i]);
        //     }
        // }
        
        // int? r = bt.GetKey(200);
        // Console.WriteLine("\n-----");
        // if(r == null) {
        //     Console.WriteLine("Couldn't find 200 in the tree");
        // } else {
        //     Console.WriteLine("Could find 200 in the tree");
            
        // }
    }
}
