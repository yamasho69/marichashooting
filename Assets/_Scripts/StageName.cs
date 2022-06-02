using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class StageName : MonoBehaviour {
    // ★追加
    private Text stageNameText;
    [Header("数字が大きいと早く消える")] public float vanishTime;
    [Header("ステージ名以外に使うときは外す")] public bool stageNameUse;
    [Header("何秒後から薄くなるか")] public float clearStartTime;
    private bool startClear = false;

    void Start() {
        // ★追加
        // 「Text」コンポーネントにアクセスして取得する。
        stageNameText = this.gameObject.GetComponent<Text>();

        if (stageNameUse) {
            // ★追加
            // 現在のシーンの名前を取得してtextプロパティにセットする（ポイント）
            stageNameText.text = SceneManager.GetActiveScene().name;
        }

        Invoke("StartClear", clearStartTime);
    }

    void Update() {
        if (startClear) {
            // ★追加
            stageNameText.color = Color.Lerp(stageNameText.color, new Color(1, 1, 1, 0), vanishTime * Time.deltaTime);
        }
    } 

    void StartClear() {
        startClear = true;
    }
}
