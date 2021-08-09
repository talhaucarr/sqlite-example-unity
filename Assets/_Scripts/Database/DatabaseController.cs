using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using TMPro;
using Utilities;

public class DatabaseController : AutoCleanupSingleton<DatabaseController>
{
    [SerializeField] private string _dbName;

    public IDatabaseConenction _dbConnection;
    private RegisterUser _registerUser;
    private LoginUser _loginUser;
   

    private CreateTable _createTable;
    
    private void Start()
    {
        InitDatabaseConnection();

        _registerUser = GetComponent<RegisterUser>();
        _loginUser = GetComponent<LoginUser>();
        _createTable = GetComponent<CreateTable>();

        CreatGameTablesIfNotExists();
    }

    private void CreatGameTablesIfNotExists()
    {
        _createTable.CreateDB("CREATE TABLE IF NOT EXISTS users (userID integer PRIMARY KEY, username VARCHAR(20), password VARCHAR(20), email VARCHAR(35));", _dbConnection);
        _createTable.CreateDB("CREATE TABLE IF NOT EXISTS weapons (weaponID integer PRIMARY KEY, ownerID integer, weaponName VARCHAR(20), damage integer, price integer, FOREIGN KEY(ownerID) REFERENCES users(userID));", _dbConnection);
        _createTable.CreateDB("CREATE TABLE IF NOT EXISTS userStats (statID integer PRIMARY KEY, userID integer, level integer,exp integer,str integer, dex integer, vitality integer, FOREIGN KEY(userID) REFERENCES users(userID));", _dbConnection);
        _createTable.CreateDB("CREATE TABLE IF NOT EXISTS userInventory (inventoryID integer PRIMARY KEY, userID integer, weaponID integer, gold integer, FOREIGN KEY(userID) REFERENCES users(userID), FOREIGN KEY(weaponID) REFERENCES weapons(weaponID));", _dbConnection);
        _createTable.CreateDB("CREATE TABLE IF NOT EXISTS market (saleID integer PRIMARY KEY, ownerID integer, price integer, FOREIGN KEY(ownerID) REFERENCES users(userID));", _dbConnection);
    }

    private void InitDatabaseConnection()
    {
        _dbConnection = GetComponent<IDatabaseConenction>();
        _dbConnection.SetDBName(_dbName);
    }

    public void Register()
    {
        _registerUser.Register(_dbConnection);     
    }

    public void Login()
    {
        if (!_loginUser.Login(_dbConnection)) { return; }       
    }
}
