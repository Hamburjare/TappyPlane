using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public int highScore;

    [SerializeField]
    TextMeshProUGUI usernameText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // else
        // {
        //     Destroy(gameObject);
        // }
    }

    private void Start()
    {
        usernameText.text = LoginManager.username;
    }

    public void SaveHighScore(int newScore)
    {
        if (newScore >= Score.GetHighScore())
            highScore = newScore;
        PlayerPrefs.SetInt(LoginManager.username + "_HighScore", highScore);
    }

    public int LoadHighScore()
    {
        return PlayerPrefs.GetInt(LoginManager.username + "_HighScore");
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey(LoginManager.username + "_HighScore");
    }
}
