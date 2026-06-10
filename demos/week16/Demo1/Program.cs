namespace Demo1;

public class Artist {

    public string Name { get; set; }
    public List<Album> Albums { get; set; } 

    public Artist(string name, List<Album> albums) {
        Name = name;
        Albums = albums;
    }


    public void SetAlbumName(int index, string name) {
        // logic for setting it

        Albums[index].SetName(name);
        
    }
    
}


public class Album {

    public Artist Artist { get; set; }
    public string Name { get; set; }
    
    public Album(string name, Artist artist) {
        Artist = artist;
        Name = name;
    }
    
    public void SetName(string name) {
        // logic for setting it
        Name = name;
    }
    
}



class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
