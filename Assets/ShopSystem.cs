using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using TMPro;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemName;

    private SqliteConnection _connection;
    private SqliteCommand _command;

    private int weaponID;

    public void Buy()
    {
        SelectItem();
    }

    private void SelectItem()
    {
        _connection = DatabaseController.Instance._dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = "SELECT * FROM weapons";
        Debug.Log(itemName.text.GetType());
        using (SqliteDataReader reader = _command.ExecuteReader())
        {

            while (reader.Read())
                Debug.Log(reader["weaponName"].GetType());
                if (reader["weaponName"] == itemName.text) 
                {
                    Debug.Log("ekliyom");
                    weaponID = int.Parse(reader["weaponID"].ToString());
                    AddItemInventory();
                }

            reader.Close();
        }

        DatabaseController.Instance._dbConnection.ConnectionCloseDB();
    }

    private void AddItemInventory()
    {
        _connection = DatabaseController.Instance._dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = $"INSERT INTO userInventory(userID, weaponID) VALUES ({UserStatsManager.Instance.UserID}, {weaponID});";

        _command.ExecuteNonQuery();

        DatabaseController.Instance._dbConnection.ConnectionCloseDB();
    }
}

