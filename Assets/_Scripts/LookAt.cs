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
        // ���O�ŃI�u�W�F�N�g����肷��̂ňꌾ��升�v�����邱�Ɓi�|�C���g�j
        target = GameObject.Find("Player");
    }

    void Update() {
        // �uLookAt���\�b�h�v�̊��p�i�|�C���g�j
        //transform.LookAt(target.transform.position);
        if (Time.timeScale == 1) {
            var diff = (target.transform.position - transform.position).normalized;

            transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
        }
    }
}
