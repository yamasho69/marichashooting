using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class BGScroll : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        transform.Translate(0, -0.01f, 0);
        if(transform.position.y < -10.08f) {
            transform.position = new Vector3(0, 10.08f, 0);
        }
    }
}
