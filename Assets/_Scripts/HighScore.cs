using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class HighScore : MonoBehaviour
{
    public GameObject highScoreText;
    public float speed = 1.0f;
    private Text text;
    private float time;
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
        if (ScoreManager.highScoreUpdate) {
            highScoreText.SetActive(true);//highScoreが更新されていたら表示
            PlayerPrefs.SetInt("SCORE", ScoreManager.highScore);//highscoreをPrefsにセーブ
            PlayerPrefs.Save();//https://futabazemi.net/unity/high_score/
        } else {
            highScoreText.SetActive(false);
        }
    }

    void Update()
    {
        //参考https://goodlucknetlife.com/unity-2daction-blinker/
        if (highScoreText) {
            text.color = GetAlphaColor(text.color);
        }
    }

    Color GetAlphaColor(Color color) {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time);
        return color;
    }
}
