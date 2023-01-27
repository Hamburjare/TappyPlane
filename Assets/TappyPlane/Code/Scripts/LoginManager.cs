using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LoginManager : MonoBehaviour
{
    
    public static string username;

    [SerializeField]
    TMP_InputField inputField;


    public void LoadGame() {
        username = inputField.text;
        PlayerPrefs.SetString("username", username);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void ExitGame() {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
