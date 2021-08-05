using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using TMPro;

public class GainManager : AutoCleanupSingleton<GainManager>
{
    [SerializeField] private GameObject gainScreen;
    [SerializeField] private TextMeshProUGUI gainHeader;
    [SerializeField] private TextMeshProUGUI gainMessage;

    public void TriggerErrorMessage(string header, string message)
    {
        gainScreen.SetActive(true);
        gainMessage.text = message;
        gainHeader.text = header;
    }

    public void SetActiveFalse()
    {
        gainScreen.SetActive(false);
        CanvasManager.Instance.BackGameScreen();
    }
}
