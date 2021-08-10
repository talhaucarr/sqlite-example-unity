using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class DropWeapon : MonoBehaviour
{
    private SqliteConnection _connection;
    private SqliteCommand _command;


    public void RandomWeapon()
    {
        int weaponCount = 0;
        int randomWeaponID;
        
        _connection = DatabaseController.Instance._dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = "SELECT * FROM weapons";

        using (SqliteDataReader reader = _command.ExecuteReader())
        {

            while (reader.Read())
                weaponCount++;
          
            randomWeaponID = Random.RandomRange(0, weaponCount + 1);

            SelectRandomWeapon(randomWeaponID);
            
            reader.Close();
        }

        DatabaseController.Instance._dbConnection.ConnectionCloseDB();
    }

    private void SelectRandomWeapon(int weaponID)
    {
        _connection = DatabaseController.Instance._dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = $"INSERT INTO userInventory(userID, weaponID) VALUES ({UserStatsManager.Instance.UserID}, {weaponID});";

        _command.ExecuteNonQuery();

        DatabaseController.Instance._dbConnection.ConnectionCloseDB();
    }
}
