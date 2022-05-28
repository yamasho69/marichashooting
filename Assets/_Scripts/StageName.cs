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

    void Start() {
        // ★追加
        // 「Text」コンポーネントにアクセスして取得する。
        stageNameText = this.gameObject.GetComponent<Text>();
    }

    void Update() {
        // ★追加
        stageNameText.color = Color.Lerp(stageNameText.color, new Color(1, 1, 1, 0), 0.5f * Time.deltaTime);
    }
}
