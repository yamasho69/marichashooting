using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class Stage02Manager : MonoBehaviour {
    public AudioClip clearSound;
    public string nextStageName;
    private bool isClear = false;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public GameObject enemy7;
    public GameObject enemy8;
    public GameObject enemy9;
    public GameObject boss;
    public GameObject stageClear;

    void Start()
    {
        ScoreManager.nowStage = SceneManager.GetActiveScene().name;//リトライ時に仕様
        StartCoroutine("StageStart"); 
    }

    private void Update() {
        if (enemy9 == null && boss != null && !isClear) {
            BossActive();
        }

        if (boss==null && !isClear) {
            isClear = true;
            StartCoroutine("StageClear");
        }
    }

    IEnumerator StageStart() {
        //ここに処理を書く
        yield return new WaitForSeconds(3f);
        enemy1.SetActive(true);
        yield return new WaitForSeconds(5f);
        enemy2.SetActive(true);
        yield return new WaitForSeconds(20f);
        enemy3.SetActive(true);
        yield return new WaitForSeconds(2f);
        enemy4.SetActive(true);
        yield return new WaitForSeconds(20f);
        enemy5.SetActive(true);
        yield return new WaitForSeconds(2f);
        enemy6.SetActive(true);
        yield return new WaitForSeconds(12f);
        enemy7.SetActive(true);
        yield return new WaitForSeconds(2f);
        enemy8.SetActive(true);
        yield return new WaitForSeconds(16.5f);
        enemy9.SetActive(true);
        //1フレーム停止
        yield return null;
        //ここに再開後の処理を書く
    }

    void BossActive() {
        if (!isClear) {
            boss.SetActive(true);
        }
    }

    IEnumerator StageClear() {
        yield return new WaitForSeconds(1.5f);
        AudioSource.PlayClipAtPoint(clearSound, Camera.main.transform.position);
        yield return new WaitForSeconds(0.5f);
        stageClear.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(nextStageName);
        yield return null;
    }
}
