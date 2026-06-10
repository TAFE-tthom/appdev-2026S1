namespace Demo2;

using System.IO;
using Microsoft.Data.Sqlite;

class Program
{

    static void CreateTable() {
        
        SqliteConnection connection = new SqliteConnection("Data Source=users.db");

        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = """
            CREATE TABLE Users(
                UserID INTEGER Primary Key,
                UserName VARCHAR(56) NOT NULL
            );
        """;

        int returnResult = command.ExecuteNonQuery();
        
        command.Dispose();

        connection.Dispose();
    }

    static void InsertUsersIntoTable() {
        
        SqliteConnection connection = new SqliteConnection("Data Source=users.db");

        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = """
            INSERT INTO Users(UserID, UserName) VALUES
                (1, 'Jeff'),
                (2, "Alice"),
                (3, 'Bob');
        """;

        int returnResult = command.ExecuteNonQuery();

        Console.WriteLine(returnResult);
        command.Dispose();

        connection.Dispose();
    }

    static void Main(string[] args)
    {
        using(SqliteConnection connection = new SqliteConnection("Data Source=users.db")) {

            connection.Open();

            using(SqliteCommand command = connection.CreateCommand()) {
                command.CommandText = """
                    SELECT UserId, UserName FROM Users;
                """;

                using(SqliteDataReader reader = command.ExecuteReader()) {

                    while(reader.Read()) {
                        int userid = reader.GetInt32(0);
                        string username = reader.GetString(1);

                        Console.WriteLine(userid + ": " + username);
                    }

                }
            }

        }

    }
}
