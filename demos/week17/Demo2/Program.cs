namespace Demo2;

using Demo2.Models;

using Microsoft.EntityFrameworkCore;

/**
 * Explanation:
 *
 * It appears that I messed up by remember that if we wanted to
 * use a collection that is locally caching, we need to use DbSet - #1
 * This is common due to wanting to cache elements locally and interacting
 * with the DbSet to extract information on what is tracked and what isn't
 *
 * However, we can directly interact with the data by doing it a different
 * way - See #2 in the Main method that allows you to specify the entity
 * you want to query - This does not require a DbSet to be constructed within
 * our context type because it will construct this dynamically
 *
 * - This may imply that everytime with #2 it will reconstruct the Set
 *   which is incorrect as it will retrieve an existing set if it already
 *   exists.
 *
 *   The main use-case for #1 or #2 comes down to static vs dynamic properties
 *   of your program.
 *
 *   #1 - If you know your sets and collections ahead of time and want to
 *        explicitly control the set easily - #1 is fit for this and is straight
 *        forward.
 *
 *   #2 - What you can do with #1 you can do here, however there is a little
 *        more flexibility.
 *        
 *        This suitable for dynamic properties or dependencies that we cannot
 *        easily modify - For example - class generation and build steps could
 *        could occur in an order where we only get a type after DbContext is
 *        build - This is
 *
 *        Another idea would be injecting the type information at runtime -
 *        Since C# supports the ability for an object to report its type - it is
 *        also possibly for the type to be generated or injected at runtime.
 *        
 *        I wouldn't be expecting many people to be doing this but it is
 *        a neat trick to pull off.
 */

class Program
{
    static void Main(string[] args)
    {

        using(var context = new ApplicationDbContext("Data Source=users.db")) {

            // #1
            // var user = context.User
            //     // Is instructed to include the posts objects associated
            //     .Include(u => u.Posts)
            //     // filters based on the user id
            //     .Where(u => u.UserId == 2)
            //     // Will get the first one in the entry
            //     .First();

            // #2
            var user = context.Set<User>() //Set is constructed or retrieved
                .Include(u => u.Posts)
                .Where(u => u.UserId == 2)
                .First();

            foreach(var p in user.Posts)
            {
                Console.Write(user.UserName + "#" + user.UserId + " Posts: ");
                Console.WriteLine(p.PostContent);
            }
            
        }
    
    }
}
