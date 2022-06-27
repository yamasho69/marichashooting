using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class Rotate : MonoBehaviour {

    public float PosX;
    public float PosY;
    public float PosZ;
    internal Vector3 pos;

    void FixedUpdate() {
        if (Time.timeScale == 1) {
            transform.Rotate(new Vector3(PosX, PosY, PosZ));
        }
    }
}
