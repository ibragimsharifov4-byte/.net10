using Npgsql;

namespace Infrastructure.Data;

public static class Database
{
    public static string connection = 
    "Host=localhost;Port=5432;Database=Booknest;Username=postgres;Password=1234";
    public static NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connection);
    }
}
