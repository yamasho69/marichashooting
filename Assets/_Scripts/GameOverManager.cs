using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class GameOverManager : MonoBehaviour
{
    [Header("GameOvervoice")] public AudioClip[] clips;
    private AudioClip destroySound;
    public GameObject button;

    private void Awake() {
        if (ScoreManager.score > ScoreManager.highScore) { //ハイスコアを更新していた場合
            ScoreManager.highScore = ScoreManager.score;
            ScoreManager.highScoreUpdate = true;
        }
    }

    void Start()
    {
        destroySound = GetRandom(clips);
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
        Invoke("ButtonActive", 1.0f);
    }

    internal static T GetRandom<T>(params T[] Params) {
        return Params[UnityEngine.Random.Range(0, Params.Length)];
    }

    private void ButtonActive() {
        button.SetActive(true);
    }
}
