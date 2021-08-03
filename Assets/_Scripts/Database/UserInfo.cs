using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Utilities;

public class UserInfo : AutoCleanupSingleton<UserInfo>
{

    private SqliteConnection _connection;
    private SqliteCommand _command;

    public void GetUserInfo(int userID, IDatabaseConenction dbConnection)
    {
        _connection = dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = "SELECT * from users WHERE userID='" + userID + "';";
        using (SqliteDataReader reader = _command.ExecuteReader())
        {
            while (reader.Read())
            {
                UserManager.Instance.UserID = userID;
                UserManager.Instance.Username = (string)reader["username"];  
            }
            reader.Close();
        }
        dbConnection.ConnectionCloseDB();
    }

    public void GetUserStatsInfo(int userID, IDatabaseConenction dbConnection)
    {
        _connection = dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = "SELECT * from userStats WHERE userID='" + userID + "';";
        using (SqliteDataReader reader = _command.ExecuteReader())
        {
            while (reader.Read())
            {
                UserManager.Instance.DEX = int.Parse(reader["level"].ToString());
                UserManager.Instance.STR = int.Parse(reader["str"].ToString());
                UserManager.Instance.DEX = int.Parse(reader["dex"].ToString());
                UserManager.Instance.STR = int.Parse(reader["vitality"].ToString());                
            }
            reader.Close();
        }
        dbConnection.ConnectionCloseDB();
    }

    public void GetUserInventoryInfo(int userID, IDatabaseConenction dbConnection)
    {
        _connection = dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = "SELECT * from userInventory WHERE userID='" + userID + "';";
        _command.ExecuteNonQuery();
        dbConnection.ConnectionCloseDB();
    }
}
