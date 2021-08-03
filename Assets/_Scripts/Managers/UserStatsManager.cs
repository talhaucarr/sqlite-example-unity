using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using TMPro;

public class UserStatsManager : AutoCleanupSingleton<UserStatsManager>
{
    [SerializeField] private TextMeshProUGUI usernameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI strText;
    [SerializeField] private TextMeshProUGUI dexText;
    [SerializeField] private TextMeshProUGUI vitText;

    [Header("Informations")]
    [SerializeField] [ShowOnly] private int userID;
    [SerializeField] [ShowOnly] private string username;
    [SerializeField] [ShowOnly] private int level;

    [Header("Inventory")]
    [SerializeField] [ShowOnly] private int totalGold;

    [Header("Stats")]
    [SerializeField] [ShowOnly] private int str;
    [SerializeField] [ShowOnly] private int dex;
    [SerializeField] [ShowOnly] private int vitality;

    public int UserID
    {
        get { return userID; }
        set { userID = value; }
    }

    public string Username
    {
        get { return username; }
        set { username = value; }
    }
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    public int TotalGold
    {
        get { return totalGold; }
        set { totalGold = value; }
    }
    public int STR
    {
        get { return str; }
        set { str = value; }
    }
    public int DEX
    {
        get { return dex; }
        set { dex = value; }
    }
    public int VIT
    {
        get { return vitality; }
        set { vitality = value; }
    }

    public void UpdateUserStatsUI()
    {
        usernameText.text = username;
        levelText.text = level.ToString();
        goldText.text = totalGold.ToString();
        strText.text = str.ToString();
        dexText.text = dex.ToString();
        vitText.text = vitality.ToString();
    }
}
