using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class DisplayTable : MonoBehaviour
{
    private SqliteConnection _connection;
    private SqliteCommand _command;

    public void DisplayWeapons(string query, IDatabaseConenction dbConnection)
    {
        _connection = dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = query;

        using (SqliteDataReader reader = _command.ExecuteReader())
        {
            while (reader.Read())
                Debug.Log("Name:" + reader["name"] + "\tDamage:" + reader["damage"]);
            reader.Close();
        }

        dbConnection.ConnectionCloseDB();
    }
}
