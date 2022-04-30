using Esercizio.Context;
using Esercizio.Models;
using MySql.Data.MySqlClient;

namespace Esercizio.Repositories;

public class OperatoreRepository
{

    private AppDB appDB = new AppDB();

    public IEnumerable<Operatore> GetOperatori()
    {
        var result = new List<Operatore>();

        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "SELECT operatore.*, sede.id as sede_id, sede.citta, sede.indirizzo FROM operatore LEFT JOIN sede ON operatore.sede_id = sede.id";
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var operatore = new Operatore()
            {
                Id = reader.GetInt16("id"),
                Ruolo = reader.GetString("ruolo"),
                Nome = reader.GetString("nome"),
                Cognome = reader.GetString("cognome"),
                Username = reader.GetString("username"),
                Password = reader.GetString("password"),
                SedeId = reader.GetInt16("sede_id")
            };
            result.Add(operatore);
        }
        appDB.Connection.Close();

        return result;
    }

    public Operatore GetOperatore(int? id)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "SELECT operatore.*, sede.id as sede_id, sede.citta, sede.indirizzo FROM operatore LEFT JOIN sede ON operatore.sede_id = sede.id WHERE operatore.id=@id";
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
            var operatore = new Operatore()
            {
                Id = reader.GetInt16("id"),
                Ruolo = reader.GetString("ruolo"),
                Nome = reader.GetString("nome"),
                Cognome = reader.GetString("cognome"),
                Username = reader.GetString("username"),
                Password = reader.GetString("password"),
                SedeId = reader.GetInt16("sede_id")
            };
            appDB.Connection.Close();
            return operatore;
        }

        appDB.Connection.Close();
        return null;
    }

    public bool Create(Operatore operatore)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "INSERT INTO operatore (id,ruolo,nome,cognome,username,password,sede_id) VALUES (@id,@ruolo,@nome,@cognome,@username,@password,@sede_id)";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = operatore.Id
        };
        command.Parameters.Add(parameterId);
        var parameterRuolo = new MySqlParameter()
        {
            ParameterName = "ruolo",
            DbType = System.Data.DbType.String,
            Value = operatore.Ruolo
        };
        command.Parameters.Add(parameterRuolo);
        var parameterNome = new MySqlParameter()
        {
            ParameterName = "nome",
            DbType = System.Data.DbType.String,
            Value = operatore.Nome
        };
        command.Parameters.Add(parameterNome);
        var parameterCognome = new MySqlParameter()
        {
            ParameterName = "cognome",
            DbType = System.Data.DbType.String,
            Value = operatore.Cognome
        };
        command.Parameters.Add(parameterCognome);
        var parameterUsername = new MySqlParameter()
        {
            ParameterName = "username",
            DbType = System.Data.DbType.String,
            Value = operatore.Username
        };
        command.Parameters.Add(parameterUsername);
        var parameterPassword = new MySqlParameter()
        {
            ParameterName = "password",
            DbType = System.Data.DbType.String,
            Value = operatore.Password
        };
        command.Parameters.Add(parameterPassword);
        var parameterSedeId = new MySqlParameter()
        {
            ParameterName = "sede_id",
            DbType = System.Data.DbType.Int16,
            Value = operatore.SedeId
        };
        command.Parameters.Add(parameterSedeId);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDB.Connection.Close();
        return result;
    }

    public bool Update(Operatore operatore)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "UPDATE operatore SET ruolo=@ruolo,nome=@nome,cognome=@cognome,username=@username,password=@password,sede_id=@sede_id WHERE operatore.id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = operatore.Id
        };
        command.Parameters.Add(parameterId);
        var parameterRuolo = new MySqlParameter()
        {
            ParameterName = "ruolo",
            DbType = System.Data.DbType.String,
            Value = operatore.Ruolo
        };
        command.Parameters.Add(parameterRuolo);
        var parameterNome = new MySqlParameter()
        {
            ParameterName = "nome",
            DbType = System.Data.DbType.String,
            Value = operatore.Nome
        };
        command.Parameters.Add(parameterNome);
        var parameterCognome = new MySqlParameter()
        {
            ParameterName = "cognome",
            DbType = System.Data.DbType.String,
            Value = operatore.Cognome
        };
        command.Parameters.Add(parameterCognome);
                var parameterUsername = new MySqlParameter()
        {
            ParameterName = "username",
            DbType = System.Data.DbType.String,
            Value = operatore.Username
        };
        command.Parameters.Add(parameterUsername);
        var parameterPassword = new MySqlParameter()
        {
            ParameterName = "password",
            DbType = System.Data.DbType.String,
            Value = operatore.Password
        };
        command.Parameters.Add(parameterPassword);
        var parameterSedeId = new MySqlParameter()
        {
            ParameterName = "sede_id",
            DbType = System.Data.DbType.Int16,
            Value = operatore.SedeId
        };
        command.Parameters.Add(parameterSedeId);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDB.Connection.Close();
        return result;
    }

    public bool Delete(int id)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "DELETE FROM operatore WHERE id=@id";
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