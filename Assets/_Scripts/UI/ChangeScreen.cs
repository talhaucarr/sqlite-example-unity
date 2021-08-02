using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreen : MonoBehaviour
{
    [SerializeField] private GameObject loginScreen;
    [SerializeField] private GameObject registerScreen;
    [SerializeField] private GameObject errorScreen;
    
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

    public void SetActive()
    {
        errorScreen.SetActive(false);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
