using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using TMPro;

public class ErrorManager : AutoCleanupSingleton<ErrorManager>
{
    [SerializeField] private GameObject errorScreen;
    [SerializeField] private TextMeshProUGUI errorMessage;

    public void TriggerLoginError(string message)
    {
        errorScreen.SetActive(true);
        errorMessage.text = message;
    }
}
