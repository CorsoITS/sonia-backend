using Esercizio.Context;
using Esercizio.Models;
using MySql.Data.MySqlClient;

namespace Esercizio.Repositories;

public class SomministrazioneRepository
{

    private AppDB appDB = new AppDB();

    public IEnumerable<Somministrazione> GetSomministrazioni()
    {
        var result = new List<Somministrazione>();

        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "SELECT * FROM somministrazione";
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var somministrazione = new Somministrazione()
            {
                id = reader.GetInt16("id"),
                vaccino = reader.GetString("vaccino"),
                dose = reader.GetString("dose"),
                data_somm = reader.GetDateTime("data_somministrazione"),
                note = reader.GetString("note"),
                operatore_id = reader.GetInt16("opertore_id"),
                persona_id = reader.GetInt16("persona_id")
            };
            result.Add(somministrazione);
        }
        appDB.Connection.Close();

        return result;
    }

    public Somministrazione GetSomministrazione(int? id)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "SELECT * FROM somministrazione WHERE id=@id";
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
            var somministrazione = new Somministrazione()
            {
                id = reader.GetInt16("id"),
                vaccino = reader.GetString("vaccino"),
                dose = reader.GetString("dose"),
                data_somm = reader.GetDateTime("data_somministrazione"),
                note = reader.GetString("note"),
                operatore_id = reader.GetInt16("opertore_id"),
                persona_id = reader.GetInt16("persona_id")
            };
            appDB.Connection.Close();
            return somministrazione;
        }

        appDB.Connection.Close();
        return null;
    }

    public bool Create(Somministrazione somministrazione)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "INSERT INTO somministrazione (id,vaccino,dose,data_somministrazione,note,opertore_id,persona_id) VALUES (@id,@vaccino,@dose,@data_somministrazione,@note,@opertore_id,@persona_id)";
        var parameterid = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = somministrazione.id
        };
        command.Parameters.Add(parameterid);
        var parameterVaccino = new MySqlParameter()
        {
            ParameterName = "vaccino",
            DbType = System.Data.DbType.String,
            Value = somministrazione.vaccino
        };
        command.Parameters.Add(parameterVaccino);
        var parameterDose = new MySqlParameter()
        {
            ParameterName = "dose",
            DbType = System.Data.DbType.String,
            Value = somministrazione.dose
        };
        command.Parameters.Add(parameterDose);
        var parameterData_somm = new MySqlParameter()
        {
            ParameterName = "data_somministrazione",
            DbType = System.Data.DbType.DateTime,
            Value = somministrazione.data_somm
        };
        command.Parameters.Add(parameterData_somm);
        var parameterNote = new MySqlParameter()
        {
            ParameterName = "note",
            DbType = System.Data.DbType.String,
            Value = somministrazione.note
        };
        command.Parameters.Add(parameterNote);
        var parameterOperatoreId = new MySqlParameter()
        {
            ParameterName = "opertore_id",
            DbType = System.Data.DbType.Int16,
            Value = somministrazione.operatore_id
        };
        command.Parameters.Add(parameterOperatoreId);
        var parameterPersonaId = new MySqlParameter()
        {
            ParameterName = "persona_id",
            DbType = System.Data.DbType.Int16,
            Value = somministrazione.persona_id
        };
        command.Parameters.Add(parameterPersonaId);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDB.Connection.Close();
        return result;
    }

    public bool Update(Somministrazione somministrazione)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "UPDATE somministrazione SET vaccino=@vaccino,dose=@dose,data_somministrazione=@data_somministrazione,note=@note,opertore_id=@opertore_id,persona_id=@persona_id WHERE somministrazione.id=@id";
        var parameterid = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = somministrazione.id
        };
        command.Parameters.Add(parameterid);
        var parametervaccino = new MySqlParameter()
        {
            ParameterName = "vaccino",
            DbType = System.Data.DbType.String,
            Value = somministrazione.vaccino
        };
        command.Parameters.Add(parametervaccino);
        var parameterdose = new MySqlParameter()
        {
            ParameterName = "dose",
            DbType = System.Data.DbType.String,
            Value = somministrazione.dose
        };
        command.Parameters.Add(parameterdose);
        var parameterCognome = new MySqlParameter()
        {
            ParameterName = "data_somministrazione",
            DbType = System.Data.DbType.DateTime,
            Value = somministrazione.data_somm
        };
        command.Parameters.Add(parameterCognome);
                var parameterUsername = new MySqlParameter()
        {
            ParameterName = "note",
            DbType = System.Data.DbType.String,
            Value = somministrazione.note
        };
        command.Parameters.Add(parameterUsername);
        var parameterPassword = new MySqlParameter()
        {
            ParameterName = "opertore_id",
            DbType = System.Data.DbType.Int16,
            Value = somministrazione.operatore_id
        };
        command.Parameters.Add(parameterPassword);
        var parameterSedeid = new MySqlParameter()
        {
            ParameterName = "persona_id",
            DbType = System.Data.DbType.Int16,
            Value = somministrazione.persona_id
        };
        command.Parameters.Add(parameterSedeid);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDB.Connection.Close();
        return result;
    }

    public bool Delete(int id)
    {
        appDB.Connection.Open();
        var command = appDB.Connection.CreateCommand();
        command.CommandText = "DELETE FROM somministrazione WHERE id=@id";
        var parameterid = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameterid);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDB.Connection.Close();
        return result;
    }

}