using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    public GameObject title1;//タイトル
    public CanvasGroup title2;//おなら。アルファ値を持っているのはキャンバスグループ
    public AudioClip titleCall1;//タイトルコール1
    public AudioClip titleCall2;//タイトルコール2
    public AudioClip onara;
    public GameObject musicName;
    public GameObject buttons;
    public GameObject highScore;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("TitleStart");
    }
    
    IEnumerator TitleStart(){
        title1.transform.DOScale(
    new Vector3(1.2f, 1.2f, 1.2f), // スケール値
    1.1f                    // 演出時間
    );
        yield return new WaitForSeconds(0.56f);
        audioSource.PlayOneShot(titleCall1);
        yield return new WaitForSeconds(0.66f);
        title1.transform.DOScale(
    new Vector3(1, 1, 1), // スケール値
    0.05f                    // 演出時間
    );
        yield return new WaitForSeconds(1.1f);
        title2.DOFade(
            1f,     // フェード後のアルファ値
            1f      // 演出時間
        );
        audioSource.PlayOneShot(onara);
        yield return new WaitForSeconds(0.40f);
        audioSource.PlayOneShot(titleCall2);
        //1フレーム停止
        yield return new WaitForSeconds(3.1f);
        audioSource.Play();
        buttons.SetActive(true);
        highScore.SetActive(true);
        musicName.SetActive(true);
        yield return null;
    }
}
