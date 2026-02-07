namespace EvenOrOdd.Test;

using TermControl;

public class NumberTest
{
    [Fact]
    public void EvenOrOdd_Test23()
    {
        TermController ctlr = new TermController()
            .RecordStdOut()
            .SetStringInput("23\n")
            .FindAndInvokeMain("Program, EvenOrOdd", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();

        Assert.Equal("Odd\n", output);

        ctlr.ResetAll();
        
    }
    [Fact]
    public void EvenOrOdd_Test20()
    {
        TermController ctlr = new TermController()
            .RecordStdOut()
            .SetStringInput("20\n")
            .FindAndInvokeMain("Program, EvenOrOdd", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();

        Assert.Equal("Even\n", output);

        ctlr.ResetAll();
        
    }
    [Fact]
    public void EvenOrOdd_TestA()
    {
        TermController ctlr = new TermController()
            .RecordStdOut()
            .SetStringInput("A\n")
            .FindAndInvokeMain("Program, EvenOrOdd", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();

        Assert.Equal("Invalid\n", output);

        ctlr.ResetAll();
        
    }
    [Fact]
    public void EvenOrOdd_TestNewLineOnly()
    {
        TermController ctlr = new TermController()
            .RecordStdOut()
            .SetStringInput("\n")
            .FindAndInvokeMain("Program, EvenOrOdd", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();

        Assert.Equal("Odd\n", output);

        ctlr.ResetAll();
        
    }
    [Fact]
    public void EvenOrOdd_TestNegative1()
    {
        TermController ctlr = new TermController()
            .RecordStdOut()
            .SetStringInput("-1\n")
            .FindAndInvokeMain("Program, EvenOrOdd", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();

        Assert.Equal("Odd\n", output);

        ctlr.ResetAll();
        
    }
    [Fact]
    public void EvenOrOdd_TestNegative20()
    {
        TermController ctlr = new TermController()
            .RecordStdOut()
            .SetStringInput("-20\n")
            .FindAndInvokeMain("Program, EvenOrOdd", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();

        Assert.Equal("Even\n", output);

        ctlr.ResetAll();
        
    }
}
