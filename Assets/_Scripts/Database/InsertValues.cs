using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class InsertValues : MonoBehaviour
{
    private SqliteConnection _connection;
    private SqliteCommand _command;

    private bool _isRegistered = false;

    public void AddValues(string query, IDatabaseConenction dbConnection)
    {
        _connection = dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = query;
        _command.ExecuteNonQuery();
        Debug.Log("Eklendi!");
        dbConnection.ConnectionCloseDB();
    }

    public bool IsUsernameTaken(string username,IDatabaseConenction dbConnection)
    {
        _connection = dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = "SELECT username from users WHERE username='" + username + "';";

        using (SqliteDataReader reader = _command.ExecuteReader())
        {
            while (reader.Read())
            {
                Debug.Log("read icinde");
                _isRegistered = true;
            }

            reader.Close();
        }

        if (_isRegistered)
        {
            ErrorManager.Instance.TriggerLoginError("Kullanici adi daha onceden alinmis!");
            return true;
        }

        dbConnection.ConnectionCloseDB();
        return false;
    }
}
