using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class Stage01Manager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("StageStart"); 
    }

    IEnumerator StageStart() {
        //‚±‚±‚Éˆ—‚ğ‘‚­

        //1ƒtƒŒ[ƒ€’â~
        yield return null;

        //‚±‚±‚ÉÄŠJŒã‚Ìˆ—‚ğ‘‚­
    }
}
