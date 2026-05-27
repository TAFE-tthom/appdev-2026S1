namespace MazeSolver.Test;


public class MazeBuildStep {
    
    public Func<Maze, Maze> Operation { get; set; }

    public MazeBuildStep(Func<Maze, Maze> operation)
    {
        Operation = operation;
    }
    
    public static MazeBuildStep Step(Func<Maze, Maze> operation) {
        return new MazeBuildStep(operation);
    }

    public Maze Operate(Maze m)
    {
        return this.Operation(m);
    }
}




public class MazeOperationStep {

    public Action<Maze> Operation { get; set; }

    public MazeOperationStep(Action<Maze> operation)
    {
        Operation = operation;
    }
    
    public static MazeOperationStep Step(Action<Maze> operation) {
        return new MazeOperationStep(operation);
    }

    public void Operate(Maze m)
    {
        this.Operation(m);
    }
}

public class MazeTestBuilder {
    public List<MazeBuildStep> BuildSteps { get; set; }
    public List<MazeOperationStep> OperationSteps { get; set; }

    private Maze? maze = null;

    public static MazeTestBuilder Make() {
        return new MazeTestBuilder();
    }

    public MazeTestBuilder AddBuildStep(MazeBuildStep step) {
        BuildSteps.Add(step);
        return this;
    } 
    public MazeTestBuilder AddOperationStep(MazeOperationStep step) {
        OperationSteps.Add(step);
        return this;
    }

    public void BuildAndRun()
    {
        Maze m = new Maze();
        foreach(var step in BuildSteps)
        {
            m = step.Operate(m);
        }

        this.Run(m);
    }

    public void Run(Maze m) {
        foreach(var step in OperationSteps)
        {
            step.Operate(m);
        }
    }
        
}


public class MazeSolverTest
{


    public static readonly string level1 =
@"XXXXXXXXXXXXX
S         X X
 X X   X  X X
 X XX  X X  X
   XXX      X
XX     XXX  X
XXXXXXXXXXXEX";


    public static readonly string level2 =
@"XXXXXXXXX
      X X
SXXX  X X
XXXXX   X
XXXXXXXEX";

    private static void LevelWalk(string[][] grid, List<Point> attempt,
        int expectedSteps, Point gstart, Point gend)
    {
        Point? prev = null;
        Point start = attempt.First();
        Point end = attempt.Last();

        for(int i = 0; i < attempt.Count(); i++)
        {
            var current = attempt[i];
            var validChar = grid[current.Y][current.X];
            Assert.NotEqual("X", validChar);

            if(prev != null) {
                var diff = Math.Abs(current.X - prev.X) +
                    Math.Abs(current.Y - prev.Y);

                Assert.Equal(1, diff);
            }
            prev = current;
        }

        Assert.Equal(gstart, start);
        Assert.Equal(gend, end);
        Assert.Equal(expectedSteps, attempt.Count());
        if(prev != null) {
            Assert.Equal(gend.X, prev.X);
            Assert.Equal(gend.Y, prev.Y);
        }

    }

    [Fact]
    public void Test_MazeVariant1()
    {
        MazeTestBuilder.Make()
            .AddBuildStep(MazeBuildStep.Step((m) => {return new Maze(); }))
            .AddBuildStep(MazeBuildStep.Step((m) => { m.SetStart(new Point(0, 1)); return m; }))
            .AddBuildStep(MazeBuildStep.Step((m) => { m.SetStart(new Point(11, 6)); return m; }))
            .AddBuildStep(MazeBuildStep.Step((m) => {
                m.SetGrid(
                    [
                      ["X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X"],
                      ["S", " ", " ", " ", " ", " ", " ", " ", " ", " ", "X", " ", "X"],
                      [" ", "X", " ", "X", " ", " ", " ", "X", " ", " ", "X", " ", "X"],
                      [" ", "X", " ", "X", "X", " ", " ", "X", " ", "X", " ", " ", "X"],
                      [" ", " ", " ", "X", "X", "X", " ", " ", " ", " ", " ", " ", "X"],
                      ["X", "X", " ", " ", " ", " ", " ", "X", "X", "X", " ", " ", "X"],
                      ["X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "E", "X"],
                    ]);
                return m;
            }))
            .AddOperationStep(MazeOperationStep.Step((m) => {
                var mazeStr = m.DrawGrid();
                Assert.Equal(level1, mazeStr);
            }))
            .BuildAndRun();
            
        
    }
    
    [Fact]
    public void Test_MazeVariant1_Solve()
    {
        MazeTestBuilder.Make()
            .AddBuildStep(MazeBuildStep.Step((m) => {return new Maze(); }))
            .AddBuildStep(MazeBuildStep.Step((m) => { m.SetStart(new Point(0, 1)); return m; }))
            .AddBuildStep(MazeBuildStep.Step((m) => { m.SetStart(new Point(11, 6)); return m; }))
            .AddBuildStep(MazeBuildStep.Step((m) => {
                m.SetGrid(
                    [
                      ["X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X"],
                      ["S", " ", " ", " ", " ", " ", " ", " ", " ", " ", "X", " ", "X"],
                      [" ", "X", " ", "X", " ", " ", " ", "X", " ", " ", "X", " ", "X"],
                      [" ", "X", " ", "X", "X", " ", " ", "X", " ", "X", " ", " ", "X"],
                      [" ", " ", " ", "X", "X", "X", " ", " ", " ", " ", " ", " ", "X"],
                      ["X", "X", " ", " ", " ", " ", " ", "X", "X", "X", " ", " ", "X"],
                      ["X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "E", "X"],
                    ]);
                return m;
            }))
            .AddOperationStep(MazeOperationStep.Step((m) => {
                var steps = m.Solve();
                LevelWalk(m.GetGrid(), steps, 17, new Point(0, 1),
                    new Point(11, 6));

            }))
            .BuildAndRun();
            
        
    }

    [Fact]
    public void Test_MazeVariant2()
    {
        MazeTestBuilder.Make()
            .AddBuildStep(MazeBuildStep.Step((m) => {return new Maze(); }))
            .AddBuildStep(MazeBuildStep.Step((m) => { m.SetStart(new Point(0, 1)); return m; }))
            .AddBuildStep(MazeBuildStep.Step((m) => { m.SetStart(new Point(11, 6)); return m; }))
            .AddBuildStep(MazeBuildStep.Step((m) => {
                m.SetGrid(
                    [
                        ["X", "X", "X", "X", "X", "X", "X", "X", "X"],
                        [" ", " ", " ", " ", " ", " ", "X", " ", "X"],
                        ["S", "X", "X", "X", " ", " ", "X", " ", "X"],
                        ["X", "X", "X", "X", "X", " ", " ", " ", "X"],
                        ["X", "X", "X", "X", "X", "X", "X", "E", "X"],
                    ]);
                return m;
            }))
            .AddOperationStep(MazeOperationStep.Step((m) => {
                var mazeStr = m.DrawGrid();
                Assert.Equal(level2, mazeStr);
            }))
            .AddOperationStep(MazeOperationStep.Step((m) => {
                Assert.Equal(9, m.GetWidth());
            }))
            .AddOperationStep(MazeOperationStep.Step((m) => {
                Assert.Equal(5, m.GetHeight());
            }))
            .AddOperationStep(MazeOperationStep.Step((m) => {
                Point p = m.GetStart();
                Assert.Equal(0, p.X);
                Assert.Equal(2, p.Y);
            }))
            .AddOperationStep(MazeOperationStep.Step((m) => {
                Point p = m.GetExit();
                Assert.Equal(7, p.X);
                Assert.Equal(4, p.Y);
            }))
            .BuildAndRun();
            
        
    }

    [Fact]
    public void Test_MazeVariant2_Solve()
    {
        MazeTestBuilder.Make()
            .AddBuildStep(MazeBuildStep.Step((m) => {return new Maze(); }))
            .AddBuildStep(MazeBuildStep.Step((m) => { m.SetStart(new Point(0, 1)); return m; }))
            .AddBuildStep(MazeBuildStep.Step((m) => { m.SetStart(new Point(11, 6)); return m; }))
            .AddBuildStep(MazeBuildStep.Step((m) => {
                m.SetGrid(
                    [
                        ["X", "X", "X", "X", "X", "X", "X", "X", "X"],
                        [" ", " ", " ", " ", " ", " ", "X", " ", "X"],
                        ["S", "X", "X", "X", " ", " ", "X", " ", "X"],
                        ["X", "X", "X", "X", "X", " ", " ", " ", "X"],
                        ["X", "X", "X", "X", "X", "X", "X", "E", "X"],
                    ]);
                return m;
            }))
            .AddOperationStep(MazeOperationStep.Step((m) => {
                var steps = m.Solve();
                LevelWalk(m.GetGrid(), steps, 12, new Point(0, 2),
                    new Point(7, 4));
            }))
            .BuildAndRun();
            
        
    }
}
