namespace Demo1;


public class HashMapEntry {

    public string Key { get; set; }
    public string Value { get; set; }

    public HashMapEntry(string key, string value)
    {
        Key = key;
        Value = value;
    }
}


public class HashMap {

    

    private List<HashMapEntry>[] entries = new List<HashMapEntry>[4];
    private int size = 0;
    

    // Simple hash function, poor distribution
    private static uint DJB2Hash(string key) {
        uint keysize = (uint) key.Length;
        uint hash = 5381; // Arbitrary

        for(int i = 0; i < keysize; i++) {
            hash = ((hash << 5) + hash) + ((uint)key[i]);
        }

        return hash;
    }

    public HashMap() {}


    public void Grow() {
        var newCapacity = entries.Length * 2;
        var oldCapacity = entries.Length;
        var oldEntries = entries;
        var newEntries = new List<HashMapEntry>[newCapacity];

        for(int i = 0; i < oldCapacity; i++) {

            List<HashMapEntry> entry = oldEntries[i];

            for(int j = 0; j < entry.Count(); j++) {
                HashMapEntry newEntry = entry[j];
                
                uint index = DJB2Hash(newEntry.Key) % (uint) newEntries.Length;

                var newBucket = newEntries[index];
                if(newBucket == null) {
                    newEntries[index] = new List<HashMapEntry>();
                    
                    newBucket = newEntries[index];
                    
                }
                newBucket.Add(newEntry);
            }
            newEntries[i] = 
        }
        // Revisit this with a hashmap!
        entries = newEntries;
    }

    // public void Insert(string key, string value) {
    //     bool exists = false;
    //     int index = 0;
    //     for(int i = 0; i < entries.Length; i++) {
    //         if(entries[i] != null) {
    //             if(entries[i].Key == key) {
    //                 exists = true;
    //                 index = i;
    //             }
    //         }
    //     }

    //     if(exists) {
    //         entries[index] = new HashMapEntry(key, value);
    //     } else {
    //         if(size >= entries.Length) {
    //             Grow();
    //         } 
    //         entries[size] = new HashMapEntry(key, value);
    //         size++;        
    //     }
        
    // }

    public void Insert(string key, string value) {
        uint index = DJB2Hash(key) % (uint) entries.Length;
        List<HashMapEntry>? bucket = entries[index];

        // Console.WriteLine(key + ":" + index + " " + size);

        if(bucket != null) {
            HashMapEntry? foundEntry = null;
            for(int i = 0; i < bucket.Count(); i++) {
                HashMapEntry ent = bucket[i];
                if(ent != null) {
                    if(ent.Key == key) {
                        foundEntry = ent;
                        bucket[i] = new HashMapEntry(key, value);
                        break;
                    }
                }
            }
            if(foundEntry == null) {
                bucket.Add(new HashMapEntry(key, value));
            }
        } else {
            if(size >= entries.Length) {
                Grow();
            }
            entries[index] = new List<HashMapEntry>();
            entries[index].Add(new HashMapEntry(key, value));
            size++;      
        }
        
    }

    public string? Get(string key) {
        string? value = null;
        uint index = DJB2Hash(key) % (uint) entries.Length;
        List<HashMapEntry>? bucket = entries[index];
        
        if(bucket != null) {
            for(int i = 0; i < bucket.Count(); i++) {
                HashMapEntry ent = bucket[i];
                if(ent != null) {
                    if(ent.Key == key) {                        
                        value = ent.Value;
                        break;
                    }
                }
            }
        }
        
        return value;
    }


    public string? Remove(string key) {
        string? value = null;
        // uint index = DJB2Hash(key) % (uint) entries.Length;
        // HashMapEntry? entry = entries[index];

        // if(entry != null) {
        //     value = entry.Value;
        //     entries[index] = null;
        //     size--;
        // }
        
        return value;
        
    }

    
}



class Program
{
    static void Main(string[] args)
    {
        HashMap addressBook = new HashMap();

        addressBook.Insert("Jeff", "jeff@rulez.com");
        addressBook.Insert("Alice", "alice@rulez.com");
        addressBook.Insert("Bob", "bob@gg.com");
        // addressBook.Insert("Carol", "carol@programming.com");
        // addressBook.Insert("Evan", "even@programming.com");

        Console.WriteLine(addressBook.Get("Jeff"));
        Console.WriteLine(addressBook.Get("Alice"));
        Console.WriteLine(addressBook.Get("Bob"));
        // Console.WriteLine(addressBook.Get("Carol"));
        // Console.WriteLine(addressBook.Get("Evan"));
    
    }
}
