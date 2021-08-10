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
    private int _registeredID;

    private void Start()
    {
        _insertValues = GetComponent<InsertValues>();
    }

    public void Register(IDatabaseConenction dbConnection)
    {
        if (_insertValues.IsUsernameTaken(username.text, dbConnection)) return;
        
        _insertValues.AddValues("INSERT INTO users (username, password, email) VALUES ('" + username.text + "','" + password.text + "','" + email.text + "');", dbConnection);
        _registeredID = UserInfoManager.Instance.GetUserID(username.text, dbConnection);

        _insertValues.AddValues($"INSERT INTO userStats(userID,level,exp,str,dex,vitality,statPoints) VALUES ({_registeredID}, {1},{0}, {10}, {10}, {10}, {3});", dbConnection);
    }

    
}
