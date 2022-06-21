using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class Retry: MonoBehaviour {
    [Header("タイトルに戻る")]public bool backTitle;

    // ★（追加）
    // 先頭に「public」をつけること（ポイント）
    public void OnRestartButtonClicked() {
        if (backTitle) {
            SceneManager.LoadScene("Title");//backTitleがonならTitleへ
            ScoreManager.nowStage = "Stage1";
        } else { SceneManager.LoadScene(ScoreManager.nowStage); }//backTitleがoffなら今のステージへ
        // ★追加
        // スコアを０に戻す。
        // 他スクリプトの中にある「静的変数」の操作方法（ポイント）
        ScoreManager.score = 0;
        ScoreManager.oneUPscore = 500;
        ScoreManager.highScoreUpdate = false;//ハイスコアを更新していた場合は更新していない状態に戻す。
        PlayerHealth.zanki = 3;
        Time.timeScale = 1;//ポーズから戻った場合は時間を動かす。
    }
}
