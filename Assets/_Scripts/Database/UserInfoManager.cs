using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Utilities;

public class UserInfoManager : AutoCleanupSingleton<UserInfoManager>
{
    private SqliteConnection _connection;
    private SqliteCommand _command;

    public int GetUserID(string username, IDatabaseConenction dbConnection)
    {
        _connection = dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = "SELECT * from users WHERE username='" + username + "';";
        using (SqliteDataReader reader = _command.ExecuteReader())
        {
            while (reader.Read())
            {
                return int.Parse(reader["userID"].ToString());
            }
            reader.Close();
        }
        dbConnection.ConnectionCloseDB();
        return 0;
    }

    public void GetUserInfo(int userID, IDatabaseConenction dbConnection)
    {
        _connection = dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = "SELECT * from users WHERE userID='" + userID + "';";
        using (SqliteDataReader reader = _command.ExecuteReader())
        {
            while (reader.Read())
            {
                UserStatsManager.Instance.UserID = userID;
                UserStatsManager.Instance.Username = (string)reader["username"];  
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
                UserStatsManager.Instance.Level = int.Parse(reader["level"].ToString());
                UserStatsManager.Instance.StatPoints = int.Parse(reader["statPoints"].ToString());
                UserStatsManager.Instance.Exp = int.Parse(reader["exp"].ToString());
                UserStatsManager.Instance.STR = int.Parse(reader["str"].ToString());
                UserStatsManager.Instance.DEX = int.Parse(reader["dex"].ToString());
                UserStatsManager.Instance.VIT = int.Parse(reader["vitality"].ToString());                
            }
            reader.Close();
        }
        dbConnection.ConnectionCloseDB();
    }

    //public void GetUserInventoryInfo(int userID, IDatabaseConenction dbConnection)
    //{
    //    _connection = dbConnection.ConnectDB();

    //    _command = _connection.CreateCommand();

    //    _command.CommandText = "SELECT * from userInventory WHERE userID='" + userID + "';";
    //    _command.ExecuteNonQuery();
    //    dbConnection.ConnectionCloseDB();
    //}
}
