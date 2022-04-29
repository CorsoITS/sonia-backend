using Esercizio.Context;
using Esercizio.Models;
using MySql.Data.MySqlClient;

namespace Esercizio.Repositories;

public class SedeRepository
{

    private AppDB appDb = new AppDB();

    public IEnumerable<Sede> GetSedi()
    {
        var result = new List<Sede>();

        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "SELECT * FROM sede";
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var sede = new Sede()
            {
                id = reader.GetInt16("id"),
                nome = reader.GetString("nome"),
                citta = reader.GetString("citta"),
                indirizzo = reader.GetString("indirizzo"),
            };
            result.Add(sede);
        }
        appDb.Connection.Close();

        return result;
    }

    public Sede GetSede(int? id)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "SELECT * FROM sede WHERE id=@id";
        var parameter = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameter);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var sede = new Sede()
            {
                id = reader.GetInt16("id"),
                nome = reader.GetString("nome"),
                citta = reader.GetString("citta"),
                indirizzo = reader.GetString("indirizzo"),
            };
            appDb.Connection.Close();
            return sede;
        }

        appDb.Connection.Close();
        return null;
    }

    public bool GetSedeBool(int? id)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "SELECT * FROM sede WHERE id=@id";
        var parameter = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameter);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var sede = new Sede()
            {
                id = reader.GetInt16("id"),
                nome = reader.GetString("nome"),
                citta = reader.GetString("citta"),
                indirizzo = reader.GetString("indirizzo"),
            };
            appDb.Connection.Close();
            return true;
        }

        appDb.Connection.Close();
        return false;
    }

    public bool Create(Sede sede)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "INSERT INTO sede (nome, citta, indirizzo) values (@nome, @citta, @indirizzo)";
        var parameterName = new MySqlParameter()
        {
            ParameterName = "nome",
            DbType = System.Data.DbType.String,
            Value = sede.nome
        };
        command.Parameters.Add(parameterName);
        var parameterCognome = new MySqlParameter()
        {
            ParameterName = "citta",
            DbType = System.Data.DbType.String,
            Value = sede.citta
        };
        command.Parameters.Add(parameterCognome);
        var parameterindirizzo = new MySqlParameter()
        {
            ParameterName = "indirizzo",
            DbType = System.Data.DbType.String,
            Value = sede.indirizzo
        };
        command.Parameters.Add(parameterindirizzo);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Update(Sede sede)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "UPDATE sede SET nome=@nome, citta=@citta, indirizzo=@indirizzo WHERE id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = sede.id
        };
        command.Parameters.Add(parameterId);
        var parameterName = new MySqlParameter()
        {
            ParameterName = "nome",
            DbType = System.Data.DbType.String,
            Value = sede.nome
        };
                var parameterCognome = new MySqlParameter()
        {
            ParameterName = "citta",
            DbType = System.Data.DbType.String,
            Value = sede.citta
        };
        command.Parameters.Add(parameterCognome);
        var parameterindirizzo = new MySqlParameter()
        {
            ParameterName = "indirizzo",
            DbType = System.Data.DbType.String,
            Value = sede.indirizzo
        };
        command.Parameters.Add(parameterindirizzo);
        command.Parameters.Add(parameterName);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Delete(int id)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "DELETE FROM sede WHERE id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameterId);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

}