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
        //ここに処理を書く

        //1フレーム停止
        yield return null;

        //ここに再開後の処理を書く
    }
}
