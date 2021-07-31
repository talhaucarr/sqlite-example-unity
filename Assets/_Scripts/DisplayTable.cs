using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class DisplayTable : MonoBehaviour
{
    private IDatabaseConenction _dbConnection;
    private SqliteConnection _connection;
    private SqliteCommand _command;

    private void Start()
    {
        _dbConnection = GetComponent<IDatabaseConenction>();

    }

    public void DisplayWeapons(string query)
    {
        _connection = _dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = query;

        using (SqliteDataReader reader = _command.ExecuteReader())
        {
            while (reader.Read())
                Debug.Log("Name:" + reader["name"] + "\tDamage:" + reader["damage"]);
            reader.Close();
        }

        _dbConnection.ConnectionCloseDB();
    }
}
