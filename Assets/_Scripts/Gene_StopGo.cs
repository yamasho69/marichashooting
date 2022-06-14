using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene_StopGo : MonoBehaviour {
    public GameObject stopGoPrefab;
    private int timeCount;
    [Header("�i���t���[��������Missile���쐬���邩")] public int missileTime = 600;

    void Update() {
        timeCount += 1;

        if (timeCount % missileTime == 0) {
            GameObject stopGo = Instantiate(stopGoPrefab, transform.position, Quaternion.identity);
            Destroy(stopGo,5f);
        }
    }
}