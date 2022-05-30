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
    // ★修正
    // 静的変数（ポイント）
    // public staticをつけることで、このScoreManagerスクリプトがついている他のオブジェクトと
    // scoreのデータを共有することができるようになります。
    public static int score = 0;
    private Text scoreLabel;

    // ★追加
    public AudioClip clearSound;
    public int clearScore;
    public string nextStageName;
    private bool isClear = false;

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

        // ★追加
        if (score > clearScore && !isClear) {
            AudioSource.PlayClipAtPoint(clearSound, Camera.main.transform.position);
            isClear = true;
            Invoke("StageClear", 3.0f);
        }
    }

    // ★追加
    void StageClear() {
        SceneManager.LoadScene(nextStageName);
    }
}
