using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Mono.Data;
using System;

public class DatabaseConnection : MonoBehaviour, IDatabaseConenction
{
    private SqliteConnection _connection;
    private string _dbName;

    public void SetDBName(string dbName)
    {
        _dbName = dbName;
    }
    public SqliteConnection ConnectDB()
    {
        _connection = new SqliteConnection("URI=file:" + _dbName + ".db");
        _connection.Open();
        return _connection;
    }
    public void ConnectionCloseDB()
    {
        _connection.Close();
    }
}
