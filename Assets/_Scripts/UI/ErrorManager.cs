using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using TMPro;

public class ErrorManager : AutoCleanupSingleton<ErrorManager>
{
    [SerializeField] private GameObject errorScreen;
    [SerializeField] private TextMeshProUGUI errorHeader;
    [SerializeField] private TextMeshProUGUI errorMessage;

    public void TriggerErrorMessage(string header,string message)
    {
        errorScreen.SetActive(true);
        errorMessage.text = message;
        errorHeader.text = header;
    }

    public void SetActiveFalse()
    {
        errorScreen.SetActive(false);
    }
}
