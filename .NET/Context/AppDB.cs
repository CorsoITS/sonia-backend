using MySql.Data.MySqlClient;

namespace Esercizio.Context;

public class AppDB 
{
    public MySqlConnection Connection {get;}
    private const string defaultConnectionString = "server=localhost;database=piattaforma_vaccini_v2;uid=root;pwd=;";

    public AppDB()
    {
        Connection = new MySqlConnection(defaultConnectionString);
    }
    public AppDB(string connectionString)
    {
        Connection = new MySqlConnection(connectionString);
    }
}
