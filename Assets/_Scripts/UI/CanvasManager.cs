using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class CanvasManager : AutoCleanupSingleton<CanvasManager>
{

    [SerializeField] private GameObject loginCanvas;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject loginScreen;
    [SerializeField] private GameObject registerScreen;
    
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
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
