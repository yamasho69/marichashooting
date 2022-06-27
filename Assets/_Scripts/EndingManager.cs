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
    public AudioClip hakushumabara;
    public AudioClip daikassai;
    public GameObject button;
    void Start()
    {
        if (ScoreManager.noContinue) {
            AudioSource.PlayClipAtPoint(daikassai, Camera.main.transform.position);
            noContinueClear.SetActive(true);
            AudioSource.PlayClipAtPoint(noContinueVoice, Camera.main.transform.position);
        } else {
            nomalClear.SetActive(true);
            AudioSource.PlayClipAtPoint(hakushumabara, Camera.main.transform.position);
            AudioSource.PlayClipAtPoint(nomalVoice, Camera.main.transform.position);
        }

        Invoke("ButtonActive", 1.0f);
    }

    private void ButtonActive() {
        button.SetActive(true);
    }
}
