namespace RunningSum.Test;

using TermControl;

public class RunningSumTest
{
    string lineBreak = Environment.NewLine;
    
    [Fact]
    public void Test_Sum_1_Only()
    {
        TermController ctlr = new TermController()
            .RecordStdOut()
            .SetStringInput($"15\n")
            .FindAndInvokeMain("Program, RunningSum", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();
        string[] nlineOutput = output.Replace("\r", "").Split("\n");
        Console.WriteLine(output + ": !!");

        Assert.Equal("Enter a number: ", nlineOutput[0]);
        Assert.Equal("Enter a number: ", nlineOutput[1]);
		Assert.Equal("The total is: 15", nlineOutput[3]);

        ctlr.ResetAll();

    }
    [Fact]
    public void Test_Sum_2()
    {
        TermController ctlr = new TermController()
            .RecordStdOut()
            .SetStringInput($"15{lineBreak}30{lineBreak}")
            .FindAndInvokeMain("Program, RunningSum", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();
        string[] nlineOutput = output.Replace("\r", "").Split("\n");
        Console.WriteLine(output + ": !!");

        Assert.Equal("Enter a number: ", nlineOutput[0]);
        Assert.Equal("Enter a number: ", nlineOutput[1]);
        Assert.Equal("Enter a number: ", nlineOutput[2]);
		Assert.Equal("The total is: 45", nlineOutput[4]);

        ctlr.ResetAll();

    }
    [Fact]
    public void Test_Sum_3()
    {
        TermController ctlr = new TermController()
            .RecordStdOut()
            .SetStringInput($"15{lineBreak}30{lineBreak}30{lineBreak}60{lineBreak}15{lineBreak}")
            .FindAndInvokeMain("Program, RunningSum", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();
        string[] nlineOutput = output.Replace("\r", "").Split("\n");
        Console.WriteLine(output + ": !!");

        Assert.Equal("Enter a number: ", nlineOutput[0]);
        Assert.Equal("Enter a number: ", nlineOutput[1]);
        Assert.Equal("Enter a number: ", nlineOutput[2]);
        Assert.Equal("Enter a number: ", nlineOutput[3]);
        Assert.Equal("Enter a number: ", nlineOutput[4]);
        Assert.Equal("Enter a number: ", nlineOutput[5]);
		Assert.Equal("The total is: 150", nlineOutput[7]);

        ctlr.ResetAll();

    }
}
