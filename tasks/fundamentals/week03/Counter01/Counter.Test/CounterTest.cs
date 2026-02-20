using Counter.Test;

namespace Counter.Test;

internal enum TestAction {
    None,
    Forward,
    Backward,
    Reset,
    Get
}

internal class CounterTestAction
{
    public TestAction Action { get; set; } = TestAction.None;
    public int Expected { get; set; } = 0;

    public CounterTestAction(TestAction action, int expected)
    {
        this.Action = action;
        this.Expected = expected;
    }

    public static CounterTestAction MakeForward()
    {
        return new CounterTestAction(TestAction.Forward, -1);   
    }

    public static CounterTestAction MakeBackward()
    {
        return new CounterTestAction(TestAction.Backward, -1);   
    }

    public static CounterTestAction MakeGet(int expected)
    {
        return new CounterTestAction(TestAction.Get, expected);   
    }
    
    public static CounterTestAction MakeReset()
    {
        return new CounterTestAction(TestAction.Reset, -1);   
    }

}

public class CounterTest
{
    
    private void TestHelper(Counter counter, CounterTestAction[] actions)
    {

        foreach(CounterTestAction a in actions)
        {
            if(a.Action == TestAction.Forward)
            {
                counter.Forward();
            }
            if(a.Action == TestAction.Backward)
            {
                counter.Backward();
            }
            if(a.Action == TestAction.Get)
            {
                int expected = a.Expected;
                Assert.Equal(expected, counter.Get());
            }
            if(a.Action == TestAction.Reset)
            {
                counter.Reset();
            }
        }
        
    }

    [Fact]
    public void Test_Counter_ZeroStart_1()
    {
        Counter counter = new Counter();
        TestHelper(
            counter,
            new CounterTestAction[] {
                CounterTestAction.MakeForward(),
                CounterTestAction.MakeGet(1),
                CounterTestAction.MakeForward(),
                CounterTestAction.MakeGet(2),
            }
        );
    }
    [Fact]
    public void Test_Counter_ZeroStart_2()
    {
        Counter counter = new Counter();
        TestHelper(
            counter,
            new CounterTestAction[] {
                CounterTestAction.MakeForward(),
                CounterTestAction.MakeGet(1),
                CounterTestAction.MakeBackward(),
                CounterTestAction.MakeGet(0),
            }
        );
    }
    [Fact]
    public void Test_Counter_ZeroStart_3()
    {
        Counter counter = new Counter();
        TestHelper(
            counter,
            new CounterTestAction[] {
                CounterTestAction.MakeForward(),
                CounterTestAction.MakeGet(1),
                CounterTestAction.MakeForward(),
                CounterTestAction.MakeGet(2),
                CounterTestAction.MakeForward(),
                CounterTestAction.MakeGet(3),
            }
        );
    }
    [Fact]
    public void Test_Counter_ZeroStart_4()
    {
        Counter counter = new Counter();
        TestHelper(
            counter,
            new CounterTestAction[] {
                CounterTestAction.MakeBackward(),
                CounterTestAction.MakeGet(-1),
                CounterTestAction.MakeBackward(),
                CounterTestAction.MakeGet(-2),
                CounterTestAction.MakeBackward(),
                CounterTestAction.MakeGet(-3),
            }
        );
    }
    [Fact]
    public void Test_Counter_WithStart_1()
    {
        Counter counter = new Counter(10);
        TestHelper(
            counter,
            new CounterTestAction[] {
                CounterTestAction.MakeBackward(),
                CounterTestAction.MakeGet(9),
                CounterTestAction.MakeBackward(),
                CounterTestAction.MakeGet(8),
                CounterTestAction.MakeBackward(),
                CounterTestAction.MakeGet(7),
            }
        );
    }
    [Fact]
    public void Test_Counter_WithStart_2()
    {
        Counter counter = new Counter(10);
        TestHelper(
            counter,
            new CounterTestAction[] {
                CounterTestAction.MakeForward(),
                CounterTestAction.MakeGet(11),
                CounterTestAction.MakeForward(),
                CounterTestAction.MakeGet(12),
                CounterTestAction.MakeForward(),
                CounterTestAction.MakeGet(13),
            }
        );
    }
    [Fact]
    public void Test_Counter_WithStart_And_Reset_1()
    {
        Counter counter = new Counter(10);
        TestHelper(
            counter,
            new CounterTestAction[] {
                CounterTestAction.MakeForward(),
                CounterTestAction.MakeGet(11),
                CounterTestAction.MakeForward(),
                CounterTestAction.MakeGet(12),
                CounterTestAction.MakeForward(),
                CounterTestAction.MakeGet(13),
                CounterTestAction.MakeReset(),
                CounterTestAction.MakeGet(10),
            }
        );
    }
    [Fact]
    public void Test_Counter_WithZero_And_Reset_1()
    {
        Counter counter = new Counter(0);
        TestHelper(
            counter,
            new CounterTestAction[] {
                CounterTestAction.MakeForward(),
                CounterTestAction.MakeForward(),
                CounterTestAction.MakeForward(),
                CounterTestAction.MakeGet(3),
                CounterTestAction.MakeReset(),
                CounterTestAction.MakeGet(0),
                
            }
        );
    }
}
