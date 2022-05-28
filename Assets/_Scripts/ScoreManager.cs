using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    // ★追加
    private int score = 0;
    private Text scoreLabel;

    void Start() {
        // ★追加
        // 「Text」コンポーネントにアクセスして取得する（ポイント）
        scoreLabel = GetComponent<Text>();
        scoreLabel.text = "SCORE:" + score;
    }

    // ★追加
    // スコアを加算するメソッド（命令ブロック）
    // 「public」をつけて外部からこのメソッドにアクセスできるようにする（重要ポイント）
    public void AddScore(int amount) {
        // 「amount」に入ってくる数値分を加算していく。
        score += amount;
        scoreLabel.text = "SCORE:" + score;
    }
}
