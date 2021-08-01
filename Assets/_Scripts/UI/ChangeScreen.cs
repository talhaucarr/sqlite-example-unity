using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreen : MonoBehaviour
{
    [SerializeField] private GameObject loginScreen;
    [SerializeField] private GameObject registerScreen;
    
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
}
