using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class EndingManager : MonoBehaviour
{
    public GameObject nomalClear;
    public GameObject noContinueClear;
    public AudioClip nomalVoice;
    public AudioClip noContinueVoice;
    public GameObject button;
    void Start()
    {
        if (ScoreManager.noContinue) {
            noContinueClear.SetActive(true);
            AudioSource.PlayClipAtPoint(noContinueVoice, Camera.main.transform.position);
        } else {
            nomalClear.SetActive(true);
            AudioSource.PlayClipAtPoint(nomalVoice, Camera.main.transform.position);
        }

        Invoke("ButtonActive", 1.0f);
    }

    private void ButtonActive() {
        button.SetActive(true);
    }
}
