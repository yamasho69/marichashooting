using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class ZankiManager : MonoBehaviour
{
    private Text zankiText = null;
    private int oldzankiNum;
    void Start()
    {
        zankiText = GetComponent<Text>();
        zankiText.text = "Å~ " + PlayerHealth.zanki;
        oldzankiNum = PlayerHealth.zanki;
    }

    void Update()
    {
        if (oldzankiNum != PlayerHealth.zanki && PlayerHealth.zanki >=0) {
            zankiText.text = "Å~ " + PlayerHealth.zanki;
            oldzankiNum = PlayerHealth.zanki;
        }
    }
}
