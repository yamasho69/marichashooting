using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene_StopGo : MonoBehaviour {
    public GameObject stopGoPrefab;
    private int timeCount;
    [Header("�i���t���[��������Missile���쐬���邩")] public float missileTime = 600;

    void Update() {
        if (Time.timeScale == 1) {
            timeCount ++;
            if (timeCount % missileTime == 0) {
                GameObject stopGo = Instantiate(stopGoPrefab, transform.position, Quaternion.identity);
                Destroy(stopGo, 5f);
            }
        }
    }
}