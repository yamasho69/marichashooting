using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class LookAt : MonoBehaviour {
    private GameObject target;

    void Start() {
        // 名前でオブジェクトを特定するので一言一句合致させること（ポイント）
        target = GameObject.Find("Player");
    }

    void Update() {
        // 「LookAtメソッド」の活用（ポイント）
        //transform.LookAt(target.transform.position);
        if (Time.timeScale == 1) {
            var diff = (target.transform.position - transform.position).normalized;

            transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
        }
    }
}
