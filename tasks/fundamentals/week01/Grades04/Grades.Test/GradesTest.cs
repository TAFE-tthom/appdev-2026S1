namespace Grades.Test;

using TermControl;


public class GradesTest
{
    [Fact]
    public void GradesTest_D()
    {
         TermController ctlr = new TermController()
            .RecordStdOut()
            .SetStringInput("60\n")
            .FindAndInvokeMain("Program, Grades", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();
        string[] nlineOutput = output.Split("\n");

        Assert.Equal("Enter your mark: ", nlineOutput[0]);

        ctlr.ResetAll();
    }

    [Fact]
    public void GradesTest_B()
    {
         TermController ctlr = new TermController()
            .RecordStdOut()
            .SetStringInput("80\n")
            .FindAndInvokeMain("Program, Grades", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();
        string[] nlineOutput = output.Split("\n");

        Assert.Equal("Enter your mark: ", nlineOutput[0]);
        Assert.Equal("B", nlineOutput[1]);

        ctlr.ResetAll();
    }

    [Fact]
    public void GradesTest_A()
    {
         TermController ctlr = new TermController()
            .RecordStdOut()
            .SetStringInput("90\n")
            .FindAndInvokeMain("Program, Grades", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();
        string[] nlineOutput = output.Split("\n");

        Assert.Equal("Enter your mark: ", nlineOutput[0]);
        Assert.Equal("A", nlineOutput[1]);
        ctlr.ResetAll();
    }

    [Fact]
    public void GradesTest_C()
    {
         TermController ctlr = new TermController()
            .RecordStdOut()
            .SetStringInput("70\n")
            .FindAndInvokeMain("Program, Grades", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();
        string[] nlineOutput = output.Split("\n");

        Assert.Equal("Enter your mark: ", nlineOutput[0]);
        Assert.Equal("C", nlineOutput[1]);

        ctlr.ResetAll();
    }

    [Fact]
    public void GradesTest_F()
    {
         TermController ctlr = new TermController()
            .RecordStdOut()
            .SetStringInput("40\n")
            .FindAndInvokeMain("Program, Grades", new string[] {});

        ctlr.FlushStdOut();

        string output = ctlr.GetOutputString();
        string[] nlineOutput = output.Split("\n");

        Assert.Equal("Enter your mark: ", nlineOutput[0]);
        Assert.Equal("F", nlineOutput[1]);

        ctlr.ResetAll();
    }

}
