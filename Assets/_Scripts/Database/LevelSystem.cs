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

    private float _userID;
    private float _requiredExp;
    private float _curExp;
    private float _curLevel;

    public void InitLevelSystem(string username, IDatabaseConenction dbConnection)
    {
        NextLevelRequiredExp();
        _dbConnection = dbConnection;
        _userID = UserInfoManager.Instance.GetUserID(username, dbConnection);
    }

    public void EarnExp(float amountExp)
    {
        _curExp += amountExp;
        IfExpIsComplete();
    }

    private void NextLevelRequiredExp()
    {
        _requiredExp = UserStatsManager.Instance.Level * UserStatsManager.Instance.Level + 100;
    }

    private void IfExpIsComplete()
    {
        if(_curExp >= _requiredExp) { LevelUp(_dbConnection); }
    }

    private void LevelUp(IDatabaseConenction dbConnection)
    {
        
        _connection = dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = $"UPDATE stats SET level = {_curLevel + 1} WHERE userID = {_userID}; " ;
        _command.ExecuteNonQuery();

        dbConnection.ConnectionCloseDB();
    }
}
