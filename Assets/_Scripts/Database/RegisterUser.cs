using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RegisterUser : MonoBehaviour
{

    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField password;
    [SerializeField] TMP_InputField email;

    public TMP_InputField Username { get => username; }
    public TMP_InputField Password { get => password; }
    public TMP_InputField Email { get => email; }

}
