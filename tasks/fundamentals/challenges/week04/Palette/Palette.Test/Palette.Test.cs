namespace Palette.Test;

using TermControl;


public class PaletteTest
{
    private const string ProgramName = "Palette.Program, Palette"; 

    [Fact]
    public void Test_NoArguments()
    {
        string expectedOutput = TermControlDataLoader.LoadContentsFromFile("files/noargs.out");
        string output = TermControlDataLoader.TermControlDefaultRunner("", ProgramName, new string[] {});

        Assert.Equal(expectedOutput, output);

    }
    [Fact]
    public void Test_NoFile()
    {
        string expectedOutput = TermControlDataLoader.LoadContentsFromFile("files/nofile.out");
        string output = TermControlDataLoader.TermControlDefaultRunner("", ProgramName, new string[] { "Missingfile.jpg"});

        Assert.Equal(expectedOutput, output);

    }
    [Fact]
    public void Test_Example1()
    {
        string expectedOutput = TermControlDataLoader.LoadContentsFromFile("files/example1.out");
        string output = TermControlDataLoader.TermControlDefaultRunner("", ProgramName, new string[] { "files/imgd.b" });

        Assert.Equal(expectedOutput, output);

    }
    [Fact]
    public void Test_Example2()
    {
        string expectedOutput = TermControlDataLoader.LoadContentsFromFile("files/example2.out");
        string output = TermControlDataLoader.TermControlDefaultRunner("", ProgramName, new string[] { "files/imge.b" });

        Assert.Equal(expectedOutput, output);


    }
    [Fact]
    public void Test_BadMagic()
    {
        string expectedOutput = TermControlDataLoader.LoadContentsFromFile("files/magic.out");
        string output = TermControlDataLoader.TermControlDefaultRunner("", ProgramName, new string[] { "files/imgbadmagic.b" });

        Assert.Equal(expectedOutput, output);


    }
    [Fact]
    public void Test_Image1()
    {
        string expectedOutput = TermControlDataLoader.LoadContentsFromFile("files/image1.out");
        string output = TermControlDataLoader.TermControlDefaultRunner("", ProgramName, new string[] { "files/img1.b" });

        Assert.Equal(expectedOutput, output);


    }
    [Fact]
    public void Test_Image2()
    {
        string expectedOutput = TermControlDataLoader.LoadContentsFromFile("files/image2.out");
        string output = TermControlDataLoader.TermControlDefaultRunner("", ProgramName, new string[] { "files/imga.b" });

        Assert.Equal(expectedOutput, output);

    }
}
