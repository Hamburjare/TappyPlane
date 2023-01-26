using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public int highScore;
    public int userHighScore;

    [SerializeField]
    TextMeshProUGUI usernameText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        // else
        // {
        //     Destroy(gameObject);
        // }
    }

    private void Start()
    {
        usernameText.text = $"{PlayerPrefs.GetString("username")} | KÄYTTÄJÄ";
    }

    public void SaveUserHighScore(int newScore)
    {
        if (newScore >= Score.GetUserHighScore())
        {
            userHighScore = newScore;
            PlayerPrefs.SetInt(PlayerPrefs.GetString("username") + "_HighScore", userHighScore);
        }
    }

    public void SaveHighScore(int newScore)
    {
        if (newScore >= Score.GetHighScore())
        {
            highScore = newScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public int LoadUserHighScore()
    {
        return PlayerPrefs.GetInt(PlayerPrefs.GetString("username") + "_HighScore");
    }

    public int LoadHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    public void ResetUserHighScore()
    {
        PlayerPrefs.DeleteKey(PlayerPrefs.GetString("username") + "_HighScore");
    }
}
