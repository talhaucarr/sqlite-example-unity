using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mono.Data.Sqlite;

public class InventorySystem : MonoBehaviour
{
    private SqliteConnection _connection;
    private SqliteCommand _command;

    public void DisplayInventory()
    {
        _connection = DatabaseController.Instance._dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = $"SELECT * FROM userInventory WHERE userID = {UserStatsManager.Instance.UserID}";

        using (SqliteDataReader reader = _command.ExecuteReader())
        {

            while (reader.Read())
                DisplayWeapon(int.Parse(reader["weaponID"].ToString()));

            reader.Close();
        }

        DatabaseController.Instance._dbConnection.ConnectionCloseDB();
    }

    private void DisplayWeapon(int id)
    {
        _connection = DatabaseController.Instance._dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = $"SELECT * FROM weapons WHERE weaponID = {id}";

        using (SqliteDataReader reader = _command.ExecuteReader())
        {

            while (reader.Read())
                Debug.Log($"Weapon Name: {reader["weaponName"]}------- Damage: {reader["damage"]} ------ Price:{reader["price"]}");

            reader.Close();
        }

        DatabaseController.Instance._dbConnection.ConnectionCloseDB();
        
    }
}
