using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class ScoreManager : MonoBehaviour {
    // ★修正
    // 静的変数（ポイント）
    // public staticをつけることで、このScoreManagerスクリプトがついている他のオブジェクトと
    // scoreのデータを共有することができるようになります。
    public static int score = 0;
    public static int oneUPscore = 500;
    public GameObject oneUPItem;
    public static string nowStage = "Stage1";//リトライ時に仕様。
    private Text scoreLabel;
    public static int highScore;//ハイスコア記録
    public static bool highScoreUpdate; //ハイスコア更新

    // ★追加
    public string nextStageName;

    void Start() {
        // ★追加
        // 「Text」コンポーネントにアクセスして取得する（ポイント）
        scoreLabel = GetComponent<Text>();
        scoreLabel.text = "SCORE:" + score;
        highScore = PlayerPrefs.GetInt("SCORE", 0);
    }

    // ★追加
    // スコアを加算するメソッド（命令ブロック）
    // 「public」をつけて外部からこのメソッドにアクセスできるようにする（重要ポイント）
    public void AddScore(int amount) {
        // 「amount」に入ってくる数値分を加算していく。
        score += amount;
        scoreLabel.text = "SCORE:" + score;

        if (score >= oneUPscore) {
            oneUPItem.SetActive(true);
            oneUPscore += 500;
        }
    } 
}
        // ★追加
        /*以下はStageManagerに移した
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
}*/
