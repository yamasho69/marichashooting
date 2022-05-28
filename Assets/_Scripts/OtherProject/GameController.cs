using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class GameController : MonoBehaviour
{
    public GameObject gameOverText;
    public Text scoreText;
    int score = 1000;
    void Start()
    {
        gameOverText.SetActive(false);
        scoreText.text = "SCORE:" + score;
    }

    public void AddScore() {
        score += 100;
        scoreText.text = "SCORE:" + score;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
    }

    public void Update() {
        if (gameOverText.activeSelf == true) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene("Stage01");
            }
        }
    }
}
