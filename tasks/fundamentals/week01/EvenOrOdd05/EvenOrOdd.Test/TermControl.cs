namespace TermControl;

using System.Reflection;

public class TermController
{

    private TextWriter stdout;
    private TextReader stdin;
    private TextWriter stderr;

    private StringWriter? stdoutRecorder;
    private StringReader? stdinRecorder;
    private StringWriter? stderrRecorder;


    public TermController()
    {
        stdout = Console.Out;
        stdin = Console.In;
        stderr = Console.Error;
    }

	//
	// Attempts to get the Main method for
	// both non-public or static or emitted variants.
	// 
    public MethodInfo? GetMain(string programName) {
        MethodInfo? mMatch = null;
		var typeinfo = Type.GetType(programName);
		if(typeinfo != null) {
			foreach(var m in typeinfo
	            .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)) {
	            if(m.Name.ToString() == "Main" || m.Name.ToString() == "<Main>$") {
	                mMatch = m;
	                break;
	            }

            }
		}
        return mMatch;	
    }

	//
	// Finds and Invokes the main function associated with
	// 
    public TermController FindAndInvokeMain(string programName, object[] args) {
        MethodInfo? m = GetMain(programName);
        if(m != null) {
            m.Invoke(null, new object[] { args });
        }
        return this;
    }

    public TermController ResetAll()
    {
        ResetStdErr();
        ResetStdIn();
        ResetStdOut();
        return this;
    }

    public TermController SetStringInput(string input)
    {
        stdinRecorder = new StringReader(input);
        Console.SetIn(stdinRecorder);
        return this;
    }

    public TermController ResetStdIn()
    {
        Console.SetIn(stdin);
        return this;
    }

    public TermController RecordStdOut()
    {
        stdoutRecorder = new StringWriter();
        Console.SetOut(stdoutRecorder);
        return this;
    }

    public void FlushStdOut()
    {
		if(stdoutRecorder != null) {
        	stdoutRecorder.Flush();
		}
    }

	//
	// Will output whatever the encoding is, which could be
	// \r\n or \n
	// 
    public string GetRawOutputString()
    {
		if(stdoutRecorder != null) {
        	return stdoutRecorder.ToString();
		} else {
			return "";
		}
    }
	
	//
	// We will use unix standard instead of windows standard
	// on the output
	// 
    public string GetOutputString()
    {
        string output = GetRawOutputString();
        string newOutput = output.Replace("\r\n", "\n");
        return newOutput;
    }

	//
	// Resets the standard output buffer to its original one
	// instead of the buffer attached
	// 
    public TermController ResetStdOut()
    {
        Console.SetOut(stdout);
        return this;
    }

	//
	// Records using a buffer, on the standard error
	// pipe
	// 
    public TermController RecordStdErr()
    {
        stderrRecorder = new StringWriter();
        Console.SetError(stderrRecorder);
        return this;
    }

	//
	// Gets the buffer that is transformed into
	// a string
	// 
    public string GetErrorString()
    {
		if(stderrRecorder != null) {
        	return stderrRecorder.ToString();
		} else {
			return "";
		}
    }

    public TermController ResetStdErr()
    {
        Console.SetError(stderr);
        return this;
    }

}
