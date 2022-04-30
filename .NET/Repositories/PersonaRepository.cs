using Esercizio.Context;
using Esercizio.Models;
using MySql.Data.MySqlClient;

namespace Esercizio.Repositories;

public class PersonaRepository
{

    private AppDB appDB = new AppDB();

    public IEnumerable<Persona> GetPeople()
    {
        var result = new List<Persona>();

        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "SELECT * FROM persona";
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var persona = new Persona()
            {
                id = reader.GetInt16("id"),
                nome = reader.GetString("nome"),
                cognome = reader.GetString("cognome"),
                cf = reader.GetString("codice_fiscale"),
            };
            result.Add(persona);
        }
        appDB.Connection.Close();

        return result;
    }

    public Persona GetPersona(int? id)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "SELECT * FROM persona WHERE id=@id";
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
            var persona = new Persona()
            {
                id = reader.GetInt16("id"),
                nome = reader.GetString("nome"),
                cognome = reader.GetString("cognome"),
                cf = reader.GetString("codice_fiscale"),
            };
            appDB.Connection.Close();
            return persona;
        }

        appDB.Connection.Close();
        return null;
    }

    public bool GetPersonaBool(int? id)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "SELECT * FROM persona WHERE id=@id";
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
            var persona = new Persona()
            {
                id = reader.GetInt16("id"),
                nome = reader.GetString("nome"),
                cognome = reader.GetString("cognome"),
                cf = reader.GetString("codice_fiscale"),
            };
            appDB.Connection.Close();
            return true;
        }

        appDB.Connection.Close();
        return false;
    }

    public bool Create(Persona persona)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "INSERT INTO persona (nome, cognome, codice_fiscale) values (@nome, @cognome, @codice_fiscale)";
        var parameterName = new MySqlParameter()
        {
            ParameterName = "nome",
            DbType = System.Data.DbType.String,
            Value = persona.nome
        };
        command.Parameters.Add(parameterName);
        var parameterCognome = new MySqlParameter()
        {
            ParameterName = "cognome",
            DbType = System.Data.DbType.String,
            Value = persona.cognome
        };
        command.Parameters.Add(parameterCognome);
        var parametercodice_fiscale = new MySqlParameter()
        {
            ParameterName = "codice_fiscale",
            DbType = System.Data.DbType.String,
            Value = persona.cf
        };
        command.Parameters.Add(parametercodice_fiscale);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDB.Connection.Close();
        return result;
    }

    public bool Update(Persona persona)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "UPDATE persona SET nome=@nome, cognome=@cognome, codice_fiscale=@codice_fiscale WHERE id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = persona.id
        };
        command.Parameters.Add(parameterId);
        var parameterName = new MySqlParameter()
        {
            ParameterName = "nome",
            DbType = System.Data.DbType.String,
            Value = persona.nome
        };
                var parameterCognome = new MySqlParameter()
        {
            ParameterName = "cognome",
            DbType = System.Data.DbType.String,
            Value = persona.cognome
        };
        command.Parameters.Add(parameterCognome);
        var parametercodice_fiscale = new MySqlParameter()
        {
            ParameterName = "codice_fiscale",
            DbType = System.Data.DbType.String,
            Value = persona.cf
        };
        command.Parameters.Add(parametercodice_fiscale);
        command.Parameters.Add(parameterName);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDB.Connection.Close();
        return result;
    }

    public bool Delete(int id)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "DELETE FROM persona WHERE id=@id";
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