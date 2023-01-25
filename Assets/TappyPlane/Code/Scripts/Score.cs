using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score = 0;

    public static int highScore = 0;

    [SerializeField]
    TextMeshProUGUI scoreText_;
    [SerializeField]
    TextMeshProUGUI highScoreText_;

    private void Start() {
        highScore = SaveManager.instance.LoadHighScore();
    }

    private void Update() {
        if(scoreText_ != null)
            scoreText_.text = $"PISTEET: {score.ToString()}";

        if(highScoreText_ != null)
            highScoreText_.text = $"PARAS: {highScore.ToString()}";
    }

    public static int GetHighScore() => highScore;
}
