using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score = 0;

    public static int userHighScore = 0;
    public static int highScore = 0;

    [SerializeField]
    TextMeshProUGUI scoreText_;
    [SerializeField]
    TextMeshProUGUI highScoreText_;
    [SerializeField]
    TextMeshProUGUI userHighScoreText_;

    private void Start() {
        userHighScore = SaveManager.instance.LoadUserHighScore();
        highScore = SaveManager.instance.LoadHighScore();
    }

    private void Update() {
        if(scoreText_ != null)
            scoreText_.text = $"PISTEET | {score.ToString()}";

        if(userHighScoreText_ != null)
            userHighScoreText_.text = $"SINUN PARAS | {userHighScore.ToString()}";

        if(highScoreText_ != null)
            highScoreText_.text = $"{highScore.ToString()} | ALLTIME PARAS";
    }

    public static int GetUserHighScore() => userHighScore;
    public static int GetHighScore() => highScore;
}
