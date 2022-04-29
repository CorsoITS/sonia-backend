using MySql.Data.MySqlClient;

namespace Esercizio.Context;

public class AppDB 
{
    private string connectionString = "server=localhost;database=piattaforma_vaccini_v2;uid=root;pwd=";

    public MySqlConnection Connection {get;}

    public AppDB()
    {
        Connection = new MySqlConnection(connectionString);
    }
}