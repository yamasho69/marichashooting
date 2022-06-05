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
        //‚±‚±‚Éˆ—‚ğ‘‚­

        //1ƒtƒŒ[ƒ€’â~
        yield return null;

        //‚±‚±‚ÉÄŠJŒã‚Ìˆ—‚ğ‘‚­
    }

    void StageClear() {
        SceneManager.LoadScene(nextStageName);
    }
}
