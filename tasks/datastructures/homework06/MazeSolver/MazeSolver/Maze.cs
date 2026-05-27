namespace MazeSolver;


// Class to assist with solving the problem
public class Point {
	public int X { get; set; }
	public int Y { get; set; }
	public Point(int x, int y) {
		X = x;
		Y = y;
	}
}

public class Maze {

	public Maze() {
		//Set defaults here or outside
	}

	public Point GetExit() {
		return new Point(-1, -1);
	}

	public void SetExit(Point end) {

	}

	public Point GetStart() {
		return new Point(-1, -1);
	}

	public void SetGrid(string[][] grid) {

	}

	public string DrawGrid() {
		return "";
	}

	public string[][] GetGrid() {
		return new string[][] {};
	}

	public void SetStart(Point start) {

	}

	public int GetWidth() {
		return 0;
	}

	public int GetHeight() {
		return 0;
	}

	public List<Point> Solve() {

		return new();
	}



	public static Maze? FromString(string mazeString) {
		return null;
	}
}

