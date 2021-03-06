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

    void Start(){
        ScoreManager.nowStage = SceneManager.GetActiveScene().name;//リトライ時に仕様
    }

    private void Update() {
        if (onmyo == null && !isStart) {
            StartCoroutine("StageStart");
            isStart = true;
        }

        if (enemy9 == null && !isClear && boss!=null) {
            BossActive();
        }

        if (boss==null && !isClear) {
            isClear = true;
            AudioSource.PlayClipAtPoint(clearSound, Camera.main.transform.position);
            StartCoroutine("StageClear");
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
        yield return new WaitForSeconds(17f);
        enemy9.SetActive(true);
        //1フレーム停止
        yield return null;
        //ここに再開後の処理を書く
    }

    IEnumerator StageClear() {
        yield return new WaitForSeconds(2.0f);
        stageClear.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(nextStageName);
        yield return null;
    }

    void BossActive() {
            boss.SetActive(true);
        }
}
