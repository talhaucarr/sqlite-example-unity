using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class UpdateValues : MonoBehaviour
{
    private SqliteConnection _connection;
    private SqliteCommand _command;

    public void CreateDB(string query, IDatabaseConenction dbConnection)
    {
        _connection = dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = query;
        _command.ExecuteNonQuery();

        dbConnection.ConnectionCloseDB();
    }
}
