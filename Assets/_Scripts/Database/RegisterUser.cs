using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mono.Data.Sqlite;

public class RegisterUser : MonoBehaviour
{

    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField password;
    [SerializeField] TMP_InputField email;

    private InsertValues _insertValues;

    private void Start()
    {
        _insertValues = GetComponent<InsertValues>();
    }

    public void Register(IDatabaseConenction dbConnection)
    {
        if (_insertValues.IsUsernameTaken(username.text, dbConnection)) return;
        
        _insertValues.AddValues("INSERT INTO users (username, password, email) VALUES ('" + username.text + "','" + password.text + "','" + email.text + "');", dbConnection);
    }
}
