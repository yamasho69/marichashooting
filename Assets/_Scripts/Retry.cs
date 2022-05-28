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
        SceneManager.LoadScene("Stage01");
    }
}
