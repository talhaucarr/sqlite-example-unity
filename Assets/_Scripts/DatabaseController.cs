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

        CreatGameTables();

        //_insertValues.AddValues("INSERT INTO users (username, password, email) VALUES ('talha', 'talha41', 'talhaucrr@gmail.com');", _dbConnection);
        _insertValues.AddValues("INSERT INTO weapons (ownerID, weaponName,damage) VALUES (1, 'kilic', 55);", _dbConnection);
        //_displayTable.DisplayWeapons("SELECT * FROM weapons;", _dbConnection);
    }

    private void CreatGameTables()

    {
        _createTable.CreateDB("CREATE TABLE IF NOT EXISTS users (userID integer PRIMARY KEY, username VARCHAR(20), password VARCHAR(20), email VARCHAR(35));", _dbConnection);
        _createTable.CreateDB("CREATE TABLE IF NOT EXISTS weapons (weaponID integer PRIMARY KEY, ownerID integer, weaponName VARCHAR(20), damage integer, FOREIGN KEY(ownerID) REFERENCES users(userID));", _dbConnection);
    }

    private void InitDatabaseConnection()
    {
        _dbConnection = GetComponent<IDatabaseConenction>();
        _dbConnection.SetDBName(_dbName);
    }
}
