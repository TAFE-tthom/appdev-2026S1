namespace CSVIterator.Test;

public enum IterAction {
    Current,
    Next,
    NextCheck,
    FinishedTrue,
    FinishedFalse,
}

public class IterActionTuple {
    public IterAction Oper { get; set; }
    public string? Value { get; set; }

    public IterActionTuple(IterAction oper, string? value)
    {
        Oper = oper;
        Value = value;
    }
}

public class IteratorTestPair {
    public CSVEnumerator Iterator { get; set; }
    public IteratorSequence Sequence { get; set; }

    public IteratorTestPair(CSVEnumerator iter, IteratorSequence seq)
    {
        Iterator = iter;
        Sequence = seq;
    }

    public void Evaluate() {
        Sequence.Process(Iterator);
    }
}

public class IteratorSequenceBuilder {

    public List<IterActionTuple> actions = new();


    public static IteratorSequenceBuilder Start() {
        return new IteratorSequenceBuilder();
    }
    
    public IteratorSequenceBuilder IsFinishedTrue() {
        actions.Add(new IterActionTuple(IterAction.FinishedTrue, null));
        return this;
        
    }
    
    public IteratorSequenceBuilder IsFinishedFalse() {
        actions.Add(new IterActionTuple(IterAction.FinishedFalse, null));
        return this;
        
    }

    public IteratorSequenceBuilder DoCheck(string value) {
        actions.Add(new IterActionTuple(IterAction.Current, value));
        return this;
    }
    
    public IteratorSequenceBuilder DoNextCheck(string value) {
        actions.Add(new IterActionTuple(IterAction.NextCheck, value));
        return this;
    }

    public IteratorSequenceBuilder DoNext() {
        actions.Add(new IterActionTuple(IterAction.Next, null));
        return this;
    }

    public IteratorTestPair WithStringInput(string input)
    {
        var iter = new CSVEnumerator(input);
        return new IteratorTestPair(iter, this.Done());
    }

    public IteratorSequence Done() {
        return new IteratorSequence(this.actions);
    }
    
}

public class IteratorSequence {

    private List<IterActionTuple> tuples = new(); 

    public IteratorSequence(List<IterActionTuple> tuples) {
        this.tuples = tuples;
    }

    public void Process(CSVEnumerator iterator) {
        foreach(var tuple in tuples) {
            var act = tuple.Oper;
            var arg = tuple.Value;

            if(act == IterAction.Current) {
                Assert.Equal(arg, iterator.CurrentValue());
            }
            else if(act == IterAction.Next) {
                iterator.GetNext();
            }
            else if(act == IterAction.NextCheck) {
                Assert.Equal(arg, iterator.GetNext());
            }
            else if(act == IterAction.FinishedTrue) {
                Assert.False(iterator.HasNext());
            }
            else if(act == IterAction.FinishedFalse) {
                Assert.True(iterator.HasNext());
            } else {
                Assert.Fail("Invalid Operation");
            }
        }
    }
    
}

public class CSVEnumeratorTest
{

    [Fact]
    public void Test_Single()
    {
        IteratorSequenceBuilder
            .Start()
            .DoNextCheck("jeff")
            .WithStringInput("jeff")
            .Evaluate();
    }

    [Fact]
    public void Test_Double()
    {

        IteratorSequenceBuilder
            .Start()
            .DoNextCheck("jeff")
            .DoNextCheck("jeffington")
            .WithStringInput("jeff,jeffington")
            .Evaluate();
    }

    [Fact]
    public void Test_Double_And_Finished()
    {
        IteratorSequenceBuilder
            .Start()
            .DoNextCheck("jeff")
            .DoNextCheck("jeffington")
            .IsFinishedTrue()
            .WithStringInput("jeff,jeffington")
            .Evaluate();

    }

    [Fact]
    public void Test_FourParts()
    {
        IteratorSequenceBuilder
            .Start()
            .DoNextCheck("jeff")
            .DoNextCheck("jeffington")
            .IsFinishedFalse()
            .DoNextCheck("0444332211")
            .DoNextCheck("kelly")
            .IsFinishedTrue()
            .WithStringInput("jeff,jeffington,0444332211,kelly")
            .Evaluate();
    }

    [Fact]
    public void Test_TwoLines()
    {
        IteratorSequenceBuilder
            .Start()
            .DoNextCheck("jeff")
            .DoNextCheck("jeffington")
            .DoNextCheck("0444332211")
            .DoNextCheck("jeff@jeff.co")
            .DoNextCheck("kelly")
            .DoNextCheck("kellyson")
            .DoNextCheck("kelly@live.com")
            .DoNextCheck("0444233357")
            .IsFinishedTrue()
            .WithStringInput("jeff,jeffington,jeff@jeff.co,0444332211\nkelly,kellyson,kelly@live.com,0444233357\n")
            .Evaluate();

    }

    // [Fact]
    // public void Test_TwoLines_Iterator()
    // {

    // }
}
