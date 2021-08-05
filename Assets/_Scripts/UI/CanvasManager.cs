using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class CanvasManager : AutoCleanupSingleton<CanvasManager>
{
    [Header("Canvas")]
    [SerializeField] private GameObject loginCanvas;
    [SerializeField] private GameObject gameCanvas;

    [Header("Login Screen")]
    [SerializeField] private GameObject loginScreen;
    [SerializeField] private GameObject registerScreen;

    [Header("Game Screen")]
    [SerializeField] private GameObject middlePanel;
    [SerializeField] private GameObject envanterScreen;
    [SerializeField] private GameObject statsScreen;
    [SerializeField] private GameObject dungeonScreen;
    [SerializeField] private GameObject shopScreen;
    [SerializeField] private GameObject gainWindow;

    public void EnableGameScreen()
    {
        loginCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }

    public void EnableLoginCanvas()
    {
        loginCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }

    public void EnableLoginScreen()
    {
        loginScreen.SetActive(true);
        registerScreen.SetActive(false);
    }

    public void EnableRegisterScreen()
    {
        loginScreen.SetActive(false);
        registerScreen.SetActive(true);
    }

    public void EnableInventoryScreen()
    {
        middlePanel.SetActive(false);
        envanterScreen.SetActive(true);
        shopScreen.SetActive(false);
        dungeonScreen.SetActive(false);
        statsScreen.SetActive(false);
    }
    public void EnableShopScreen()
    {
        middlePanel.SetActive(false);
        envanterScreen.SetActive(false);
        shopScreen.SetActive(true);
        dungeonScreen.SetActive(false);
        statsScreen.SetActive(false);
    }
    public void EnableStasScreen()
    {
        middlePanel.SetActive(false);
        envanterScreen.SetActive(false);
        shopScreen.SetActive(false);
        dungeonScreen.SetActive(false);
        statsScreen.SetActive(true);
    }
    public void EnableDungeonScreen()
    {
        middlePanel.SetActive(false);
        envanterScreen.SetActive(false);
        shopScreen.SetActive(false);
        dungeonScreen.SetActive(true);
        statsScreen.SetActive(false);
    }

    public void BackGameScreen()
    {
        middlePanel.SetActive(true);
        envanterScreen.SetActive(false);
        shopScreen.SetActive(false);
        dungeonScreen.SetActive(false);
        statsScreen.SetActive(false);
    }

    public void DisableAllGameScreen()
    {
        middlePanel.SetActive(false);
        envanterScreen.SetActive(false);
        shopScreen.SetActive(false);
        dungeonScreen.SetActive(false);
        statsScreen.SetActive(false);
    }



    public void ExitGame()
    {
        Application.Quit();
    }
}
