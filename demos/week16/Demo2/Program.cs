namespace Demo2;

public interface RenderableObject {


    void Render();

    void Update(GameData data);
    
}


public interface CollidableObject {

    bool CollisionCheck(CollidableObject obj);
    
}

public class Animal : RenderableObject, CollidableObject {
    
}


public void DrawAllRenderable(List<RenderableObject> objects) {
    foreach(var r in objects) {
        r.Render();
    }
}











// Enforcing implementation without interfaces

public class Operation {


    public int apply(int x, int y) {
        throw new NotImplementedException();
        return 0;
    }
    
}

public class AddOper : Operation {
    
}


public class SubOper : Operation {
    
}


class Program
{
    static void Main(string[] args)
    {

        Operation op1 = new AddOper();
        Operation op2 = new SubOper();


        Console.WriteLine(op1.apply(op2.apply(10, 5), 7)); // 12
    
    }
}
