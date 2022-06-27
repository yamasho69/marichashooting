using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class Stage03Manager : MonoBehaviour {
    public AudioClip clearSound;
    public string nextStageName;
    private bool isClear = false;
    private bool isStart = false;
    public GameObject onmyo;
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

    //private float totalTime;

    void Start()
    {
        ScoreManager.nowStage = SceneManager.GetActiveScene().name;//リトライ時に仕様

    }

    private void Update() {
        //totalTime += Time.deltaTime;
        //Debug.Log(totalTime);

        if (onmyo == null && !isStart) {
            StartCoroutine("StageStart");
            isStart = true;
        }

        if (enemy9 == null && !isClear) {
            Invoke("BossActive", 3.0f);
        }


        if (boss==null && !isClear) {
            AudioSource.PlayClipAtPoint(clearSound, Camera.main.transform.position);
            isClear = true;
            if (ScoreManager.score > ScoreManager.highScore) { //ハイスコアを更新していた場合
                ScoreManager.highScore = ScoreManager.score;
                ScoreManager.highScoreUpdate = true;
            }
            Invoke("StageClearText", 2.0f);
            Invoke("StageClear", 5.0f);
        }
    }

    IEnumerator StageStart() {
        //ここに処理を書く
        yield return new WaitForSeconds(1f);
        enemy1.SetActive(true);
        yield return new WaitForSeconds(16.5f);

        enemy2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        enemy3.SetActive(true);
        yield return new WaitForSeconds(15f);

        enemy4.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        enemy5.SetActive(true);
        yield return new WaitForSeconds(19f);

        enemy6.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        enemy7.SetActive(true);
        yield return new WaitForSeconds(1f);
        enemy8.SetActive(true);

        yield return new WaitForSeconds(20f);
        enemy9.SetActive(true);
        //1フレーム停止
        yield return null;
        //ここに再開後の処理を書く
    }

    void StageClear() {
        SceneManager.LoadScene(nextStageName);
    }

    void StageClearText() {
        stageClear.SetActive(true);
    }

    void BossActive() {
        boss.SetActive(true);
    }
}
