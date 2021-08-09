using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Utilities;

public class LevelSystem : MonoBehaviour
{
    private IDatabaseConenction _dbConnection;
    private SqliteConnection _connection;
    private SqliteCommand _command;

    private float _requiredExp;
    private float _curExp;
    private float _curLevel;

    private void Start()
    {
        NextLevelRequiredExp();
    }

    private void NextLevelRequiredExp()
    {
        _requiredExp = UserStatsManager.Instance.Level * UserStatsManager.Instance.Level * 2 + 8;
    }

    private void IfExpIsComplete()
    {
        if(UserStatsManager.Instance.Exp >= _requiredExp) 
        { 
            LevelUp(1);
            NextLevelRequiredExp();
        }
    }

    private void LevelUp(float level)
    {
        
        _connection = DatabaseController.Instance._dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        UserStatsManager.Instance.Level += (int)level;

        _command.CommandText = $"UPDATE userStats SET level = {UserStatsManager.Instance.Level} WHERE userID = {UserStatsManager.Instance.UserID}; " ;
        _command.ExecuteNonQuery();

        DatabaseController.Instance._dbConnection.ConnectionCloseDB();
    }

    public void GainExp(float exp)
    {
        _connection = DatabaseController.Instance._dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        UserStatsManager.Instance.Exp += (int)exp;

        _command.CommandText = $"UPDATE userStats SET exp = {UserStatsManager.Instance.Exp} WHERE userID = {UserStatsManager.Instance.UserID}; ";
        _command.ExecuteNonQuery();

        DatabaseController.Instance._dbConnection.ConnectionCloseDB();

        IfExpIsComplete();
    }
}
