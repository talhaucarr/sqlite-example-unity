using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mono.Data.Sqlite;

public class LoginUser : MonoBehaviour
{
    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField password;

    private SqliteConnection _connection;
    private SqliteCommand _command;
    private int temp;
    private bool _isLogin = false;

    public bool Login(IDatabaseConenction dbConnection)
    {

        
        _connection = dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = "SELECT * from users WHERE username='"+username.text+"' AND password ='"+password.text+"';";

        using (SqliteDataReader reader = _command.ExecuteReader())
        {
            while (reader.Read())
            {
                Debug.Log("Name:" + reader["userID"].GetType() + "\tDamage:" + reader["password"]);
                temp = int.Parse(reader["userID"].ToString());
                _isLogin = true;
            }
                
            reader.Close();
        }

        if (!_isLogin)
        {
            ErrorManager.Instance.TriggerErrorMessage("Login Error","Kullanici adi veya Sifre hatali!");
            return false;
        }

        UserInfo.Instance.GetUserInfo(temp, dbConnection);
        UserInfo.Instance.GetUserStatsInfo(temp, dbConnection);


        dbConnection.ConnectionCloseDB();
        return true;
    }

}