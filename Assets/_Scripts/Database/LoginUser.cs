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

    public TMP_InputField Username { get => username; }
    public TMP_InputField Password { get => password; }

    public void Login(IDatabaseConenction dbConnection)
    {
        Debug.Log("here");
        _connection = dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = "SELECT username from users WHERE username='"+username+ "' AND password = '" + password + "';";

        dbConnection.ConnectionCloseDB();

    }

}
