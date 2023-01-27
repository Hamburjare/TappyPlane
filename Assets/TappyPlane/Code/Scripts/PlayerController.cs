using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Vector2 flyForce_ = new(0, 300);

    Rigidbody2D rb_;

    private void Awake()
    {
        rb_ = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        SaveManager.instance.SaveUserHighScore(Score.score);
        SaveManager.instance.SaveHighScore(Score.score);
        PlayerPrefs.DeleteKey("username");
        Score.score = 0;

        SceneManager.LoadScene(0);
    }

    // Input Action - Jump
    void OnJump()
    {
        rb_.velocity = Vector2.zero;

        rb_.AddForce(flyForce_);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ObstacleDone")
        {
            Score.score++;
        }
    }
}
