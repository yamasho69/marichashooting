using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class Retry: MonoBehaviour {
    // ★（追加）
    // 先頭に「public」をつけること（ポイント）
    public void OnRestartButtonClicked() {
        SceneManager.LoadScene("Stage1");
        // ★追加
        // スコアを０に戻す。
        // 他スクリプトの中にある「静的変数」の操作方法（ポイント）
        ScoreManager.score = 0;
        ScoreManager.oneUPscore = 500;
        PlayerHealth.zanki = 3;
    }
}
