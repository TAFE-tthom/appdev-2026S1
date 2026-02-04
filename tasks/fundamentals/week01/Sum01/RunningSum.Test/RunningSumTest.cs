namespace RunningSum.Test;

using TermControl;

public class RunningSumTest
{
    [Fact]
    public void Test_Sum_1_Only()
    {
        TermController ctlr = new TermController()
            .RecordStdOut()
            .SetStringInput("15\n")
            .FindAndInvokeMain("Program, RunningSum", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();
        string[] nlineOutput = output.Split("\n");
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
            .SetStringInput("15\n30\n")
            .FindAndInvokeMain("Program, RunningSum", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();
        string[] nlineOutput = output.Split("\n");
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
            .SetStringInput("15\n30\n30\n60\n15\n")
            .FindAndInvokeMain("Program, RunningSum", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();
        string[] nlineOutput = output.Split("\n");
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
