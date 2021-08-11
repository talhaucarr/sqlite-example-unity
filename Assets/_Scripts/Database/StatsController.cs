using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using TMPro;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI strInfoText;
    [SerializeField] private TextMeshProUGUI dexInfoText;
    [SerializeField] private TextMeshProUGUI vitInfoText;

    [Header("Buttons")]
    [SerializeField] private Button strUpButton;
    [SerializeField] private Button strDownButton;
    [SerializeField] private Button dexUpButton;
    [SerializeField] private Button dexDownButton;
    [SerializeField] private Button vitUpButton;
    [SerializeField] private Button vitDownButton;

    private SqliteConnection _connection;
    private SqliteCommand _command;

    private int _curPoints;
    private int _maxPoints;

    private void Start()
    {
        strInfoText.text = UserStatsManager.Instance.STR.ToString();
        dexInfoText.text = UserStatsManager.Instance.DEX.ToString();
        vitInfoText.text = UserStatsManager.Instance.VIT.ToString();
        InitCurPoints();
    }

    private void Update()
    {
        if (_curPoints <= 0)
        {
            strUpButton.gameObject.SetActive(false);
            dexUpButton.gameObject.SetActive(false);
            vitUpButton.gameObject.SetActive(false);
            
        }
        if(_curPoints == _maxPoints)
        {
            strDownButton.gameObject.SetActive(false);
            dexDownButton.gameObject.SetActive(false);
            vitDownButton.gameObject.SetActive(false);
        }
        else
        {
            strDownButton.gameObject.SetActive(true);
            dexDownButton.gameObject.SetActive(true);
            vitDownButton.gameObject.SetActive(true);
        }
    }

    public void InitCurPoints()
    {
        _curPoints = UserStatsManager.Instance.StatPoints;
        _maxPoints = UserStatsManager.Instance.StatPoints;
       
    }

    public void STRUp()
    {      
        strInfoText.text = (int.Parse(strInfoText.text) + 1).ToString();
        UserStatsManager.Instance.STR += 1;
        UpdateStat("str", UserStatsManager.Instance.STR);
        _curPoints--;
        UserStatsManager.Instance.StatPoints -= 1;
        UpdateStat("statPoints", UserStatsManager.Instance.StatPoints);
    }

    public void STRDown()
    {
        strInfoText.text = (int.Parse(strInfoText.text) - 1).ToString();
        UserStatsManager.Instance.STR -= 1;
        UpdateStat("str", UserStatsManager.Instance.STR);
        _curPoints++;
        UserStatsManager.Instance.StatPoints += 1;
        UpdateStat("statPoints", UserStatsManager.Instance.StatPoints);
    }
    public void DEXUp()
    {
        dexInfoText.text = (int.Parse(dexInfoText.text) + 1).ToString();
        UserStatsManager.Instance.DEX += 1;
        UpdateStat("str", UserStatsManager.Instance.DEX);
        _curPoints--;
        UserStatsManager.Instance.StatPoints -= 1;
        UpdateStat("statPoints", UserStatsManager.Instance.StatPoints);

    }

    public void DEXDown()
    {
        dexInfoText.text = (int.Parse(dexInfoText.text) - 1).ToString();
        UserStatsManager.Instance.STR -= 1;
        UpdateStat("str", UserStatsManager.Instance.STR);
        _curPoints++;
        UserStatsManager.Instance.StatPoints += 1;
        UpdateStat("statPoints", UserStatsManager.Instance.StatPoints);
    }
    public void VITUp()
    {
        vitInfoText.text = (int.Parse(vitInfoText.text) + 1).ToString();
        UserStatsManager.Instance.VIT += 1;
        UpdateStat("str", UserStatsManager.Instance.VIT);
        _curPoints--;
        UserStatsManager.Instance.StatPoints -= 1;
        UpdateStat("statPoints", UserStatsManager.Instance.StatPoints);
    }

    public void VITDown()
    {
        vitInfoText.text = (int.Parse(vitInfoText.text) - 1).ToString();
        UserStatsManager.Instance.VIT -= 1;
        UpdateStat("str", UserStatsManager.Instance.VIT);
        _curPoints++;
        UserStatsManager.Instance.StatPoints += 1;
        UpdateStat("statPoints", UserStatsManager.Instance.StatPoints);
    }

    private void UpdateStat(string statName,int statAmount)
    {
        _connection = DatabaseController.Instance._dbConnection.ConnectDB();

        _command = _connection.CreateCommand();

        _command.CommandText = $"UPDATE userStats SET {statName} = {statAmount} WHERE userID = {UserStatsManager.Instance.UserID};";

        _command.ExecuteNonQuery();

        DatabaseController.Instance._dbConnection.ConnectionCloseDB();
    }
}
