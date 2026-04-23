namespace demo01;

interface BinaryOperation {
    int Apply(int a, int b);
}

class AddOperation : BinaryOperation {
    public int Apply(int a, int b) {
        return a + b;
    }
}

class SubOperation : BinaryOperation {
    public int Apply(int a, int b) {
        return a - b;
    }
}

class MulOperation : BinaryOperation {
    public int Apply(int a, int b) {
        return a * b;
    }
}

class DivOperation : BinaryOperation {
    public int Apply(int a, int b) {
        return a / b;
    }
}


class Program
{
    static void Main(string[] args)
    {
        BinaryOperation add = new AddOperation();
        BinaryOperation sub = new SubOperation();
        BinaryOperation mul = new MulOperation();

        BinaryOperation[] operations = new BinaryOperation[] {
            mul, // 2, 3
            sub, // R, 5
            add, // R, 10
        };

        // ((2 * 3) - 5) + 10
        // R = (2 * 3)
        // R = R - 5
        // R = R + 10
        int res = add.Apply(sub.Apply(mul.Apply(2, 3), 5), 10);

        Console.WriteLine(res);
    }
}
