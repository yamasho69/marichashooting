using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class Stage01Manager : MonoBehaviour {
    public AudioClip clearSound;
    public string nextStageName;
    private bool isClear = false;
    private bool bossDestroy = false;

    void Start()
    {
        StartCoroutine("StageStart"); 
    }

    private void Update() {
        if (bossDestroy && !isClear) {
            AudioSource.PlayClipAtPoint(clearSound, Camera.main.transform.position);
            isClear = true;
            Invoke("StageClear", 4.5f);
        }
    }

    IEnumerator StageStart() {
        //ここに処理を書く

        //1フレーム停止
        yield return null;

        //ここに再開後の処理を書く
    }

    void StageClear() {
        SceneManager.LoadScene(nextStageName);
    }
}
