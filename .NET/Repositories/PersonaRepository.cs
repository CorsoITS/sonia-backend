using Esercizio.Context;
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
                Id = reader.GetInt16("id"),
                Nome = reader.GetString("nome"),
                Cognome = reader.GetString("cognome"),
                CF = reader.GetString("codice_fiscale")
            };
            result.Add(persona);
        }
        appDB.Connection.Close();

        return result;
    }

    public Persona GetPerson(int id)
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
                Id = reader.GetInt16("id"),
                Nome = reader.GetString("nome"),
                Cognome = reader.GetString("cognome"),
                CF = reader.GetString("codice_fiscale")
            };
            appDB.Connection.Close();
            return persona;
        }

        appDB.Connection.Close();
        return null;
    }

    public bool Create(Persona persona)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "INSERT INTO persona (id,nome,cognome,codice_fiscale) values (@id,@nome,@cognome,@codice_fiscale)";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = persona.Id
        };
        command.Parameters.Add(parameterId);
        var parameterNome = new MySqlParameter()
        {
            ParameterName = "nome",
            DbType = System.Data.DbType.String,
            Value = persona.Nome
        };
        command.Parameters.Add(parameterNome);
        var parameterCognome = new MySqlParameter()
        {
            ParameterName = "cognome",
            DbType = System.Data.DbType.String,
            Value = persona.Cognome
        };
        command.Parameters.Add(parameterCognome);
        var parameterCF = new MySqlParameter()
        {
            ParameterName = "codice_fiscale",
            DbType = System.Data.DbType.String,
            Value = persona.Cognome
        };
        command.Parameters.Add(parameterCF);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDB.Connection.Close();
        return result;
    }

    public bool Update(Persona persona)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "UPDATE persona SET nome=@nome,cognome=@cognome,codice_fiscale=@codice_fiscale WHERE id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = persona.Id
        };
        command.Parameters.Add(parameterId);
        var parameterNome = new MySqlParameter()
        {
            ParameterName = "nome",
            DbType = System.Data.DbType.String,
            Value = persona.Nome
        };
        command.Parameters.Add(parameterNome);
        var parameterCognome = new MySqlParameter()
        {
            ParameterName = "cognome",
            DbType = System.Data.DbType.String,
            Value = persona.Cognome
        };
        command.Parameters.Add(parameterCognome);
        var parameterCF = new MySqlParameter()
        {
            ParameterName = "codice_fiscale",
            DbType = System.Data.DbType.String,
            Value = persona.CF
        };
        command.Parameters.Add(parameterCF);
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