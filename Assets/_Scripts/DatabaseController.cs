using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class DatabaseController : MonoBehaviour
{
    [SerializeField] private string _dbName;

    private IDatabaseConenction _dbConnection;
    private CreateTable _createTable;
    private InsertValues _insertValues;
    private DisplayTable _displayTable;
    
    private void Start()
    {
        InitDatabaseConnection();

        _createTable = GetComponent<CreateTable>();
        _insertValues = GetComponent<InsertValues>();
        _displayTable = GetComponent<DisplayTable>();

        _createTable.CreateDB("CREATE TABLE IF NOT EXISTS weapons (name VARCHAR(20), damage INT);");

        _insertValues.AddValues("INSERT INTO weapons(name, damage) VALUES ('ss', 20);");

        _displayTable.DisplayWeapons("SELECT * FROM weapons;");
    }

    private void InitDatabaseConnection()
    {
        _dbConnection = GetComponent<IDatabaseConenction>();
        _dbConnection.SetDBName(_dbName);
    }




}
