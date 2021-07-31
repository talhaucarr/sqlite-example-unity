using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class InsertValues : MonoBehaviour
{
    private SqliteConnection _connection;
    private SqliteCommand _command;

    public void AddValues(string query, IDatabaseConenction dbConnection)
    {
        _connection = dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = query;
        _command.ExecuteNonQuery();

        dbConnection.ConnectionCloseDB();
    }
}
