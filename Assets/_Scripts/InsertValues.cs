using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class InsertValues : MonoBehaviour
{
    private IDatabaseConenction _dbConnection;
    private SqliteConnection _connection;
    private SqliteCommand _command;

    private void Start()
    {
        _dbConnection = GetComponent<IDatabaseConenction>();

    }

    public void AddValues(string query)
    {
        _connection = _dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = query;
        _command.ExecuteNonQuery();

        _dbConnection.ConnectionCloseDB();
    }
}
