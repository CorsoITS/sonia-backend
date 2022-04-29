using Esercizio.Context;
using MySql.Data.MySqlClient;

namespace Esercizio.Repositories;

public class SedeRepository
{

    private AppDB appDB = new AppDB();

    public IEnumerable<Sede> GetSedi()
    {
        var result = new List<Sede>();

        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "SELECT * FROM sede";
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var sede = new Sede()
            {
                Id = reader.GetInt16("id"),
                Nome = reader.GetString("nome"),
                Citta = reader.GetString("citta"),
                Indirizzo = reader.GetString("indirizzo")
            };
            result.Add(sede);
        }
        appDB.Connection.Close();

        return result;
    }

    public Sede GetSede(int id)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
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
                Id = reader.GetInt16("id"),
                Nome = reader.GetString("nome"),
                Citta = reader.GetString("citta"),
                Indirizzo = reader.GetString("indirizzo")
            };
            appDB.Connection.Close();
            return sede;
        }

        appDB.Connection.Close();
        return null;
    }

    public bool Create(Sede sede)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "INSERT INTO sede (id,nome,citta,indirizzo) values (@id,@nome,@citta,@indirizzo)";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = sede.Id
        };
        command.Parameters.Add(parameterId);
        var parameterNome = new MySqlParameter()
        {
            ParameterName = "nome",
            DbType = System.Data.DbType.String,
            Value = sede.Nome
        };
        command.Parameters.Add(parameterNome);
        var parameterCitta = new MySqlParameter()
        {
            ParameterName = "citta",
            DbType = System.Data.DbType.String,
            Value = sede.Citta
        };
        command.Parameters.Add(parameterCitta);
        var parameterIndirizzo = new MySqlParameter()
        {
            ParameterName = "indirizzo",
            DbType = System.Data.DbType.String,
            Value = sede.Citta
        };
        command.Parameters.Add(parameterIndirizzo);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDB.Connection.Close();
        return result;
    }

    public bool Update(Sede sede)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "UPDATE sede SET nome=@nome,citta=@citta,indirizzo=@indirizzo WHERE id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = sede.Id
        };
        command.Parameters.Add(parameterId);
        var parameterNome = new MySqlParameter()
        {
            ParameterName = "nome",
            DbType = System.Data.DbType.String,
            Value = sede.Nome
        };
        command.Parameters.Add(parameterNome);
        var parameterCitta = new MySqlParameter()
        {
            ParameterName = "citta",
            DbType = System.Data.DbType.String,
            Value = sede.Citta
        };
        command.Parameters.Add(parameterCitta);
        var parameterIndirizzo = new MySqlParameter()
        {
            ParameterName = "indirizzo",
            DbType = System.Data.DbType.String,
            Value = sede.Indirizzo
        };
        command.Parameters.Add(parameterIndirizzo);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDB.Connection.Close();
        return result;
    }

    public bool Delete(int id)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "DELETE FROM sede WHERE id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameterId);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDB.Connection.Close();
        return result;
    }

}