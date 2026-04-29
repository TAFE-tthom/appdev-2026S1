namespace Demo1;

class BinaryHeapRemoveState {
    public int LeftIndex { get; set; }
    public int RightIndex { get; set; }

    public BinaryHeapRemoveState(int left, int right) {
        LeftIndex = left;
        RightIndex = right;
    }
    
}

class BinaryHeap {

    public List<int> nodes = new List<int>();

    public BinaryHeap() {

        
    }


    public void Insert(int value) {
        //1. Find the next best spot
        int index = nodes.Count();
        bool swapped = true;
        nodes.Add(value);
        while(index > 0 && swapped) {
            swapped = false;
            // int parentIndex = (index / 2) - 1;
            int parentIndex = (index / 2);
            int parentValue = nodes[parentIndex];

            if(value < parentValue) {
                // 2. Swap!
                nodes[index] = parentValue;
                nodes[parentIndex] = value;
                swapped = true;
                index = parentIndex;   
            }    
        }
        
    }

    private BinaryHeapRemoveState GetChildren(int index) {
        int left = (index * 2) + 1;
        int right = (index * 2) + 2;

        return new BinaryHeapRemoveState(left, right);        
    }

    public bool IsEmpty() {
        return nodes.Count() == 0;
    }

    public int? RemoveMin() {
        // Check we have any nodes
        if(nodes.Count() > 0) {

            // Get the smallest (root) then swap with
            // Newly inserted and shuffle down through swaps
            int min = nodes[0];

            int lastNodeIndex = nodes.Count() - 1;
            int lastNodeValue = nodes[lastNodeIndex];
            // 3. Place lastNode at nodes[0]

            nodes[0] = lastNodeValue;
            // Remove the last one
            nodes.RemoveAt(nodes.Count() - 1);

            // 4. Swap until it is in the correct position

            int index = 0;
            int currentValue = lastNodeValue;
            bool swapped = true;

            while(index < nodes.Count() && swapped) {
                swapped = false;
                BinaryHeapRemoveState data = GetChildren(index);

                int leftIndex = data.LeftIndex;
                int rightIndex = data.RightIndex;
                if(leftIndex >= nodes.Count()
                    || rightIndex >= nodes.Count()) {

                    break;        
                }
                
                int leftValue = nodes[leftIndex];
                int rightValue = nodes[rightIndex];

                if(leftValue < currentValue) {
                    if(leftValue < rightValue) {
                        // Swap with left value
                        nodes[index] = leftValue;
                        nodes[leftIndex] = currentValue;
                        index = leftIndex;
                        swapped = true;
                    } else {
                        // Swap with right value
                        nodes[index] = rightValue;
                        nodes[rightIndex] = currentValue;
                        index = rightIndex;
                        swapped = true;
                    }
                } else if(rightValue < currentValue) {
                    nodes[index] = rightValue;
                    nodes[rightIndex] = currentValue;
                    index = rightIndex;
                    swapped = true;
                }
            
            }
            
            return min;
        }
        
        return null;
    }
    
}


class Program
{
    static void Main(string[] args)
    {
        BinaryHeap heap = new BinaryHeap();

        int[] numbers = [ 60, 40, 70, 90, 76, 10, 20, 100];

        for(int i = 0; i < numbers.Length; i++) {
            heap.Insert(numbers[i]);
        }

        while(!heap.IsEmpty()) {
            int? v = heap.RemoveMin();

            Console.WriteLine(v);
        }
    
    }
}

/*

(WeakLink) Array Contruction
   0    1    2   3    4    5     6   7    8    9    10
| 20 | 50 | 55 | 67 | 63 | 57 | 60 | 70 | 89 | 87 | 48 |   |   |   |   |

- Capacity - Size of the array
- Length - number of elements contained

-> GetParent(i) = (i / 2) - 1

StrongLink Construction

                  20
             /         \
         50              55
       /    \           /   \
     67      63      57      60
    /  \     / \
   70   89  87  (48)

-> Level before leaf nodes- 3,4 [67, 63, 57, 60] - Additional information
                                                    Keeps track of this
-> Find next free spot - 8 children, keep a count, Currently at = 3


*/
