using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene_StopGo : MonoBehaviour {
    public GameObject stopGoPrefab;
    [Header("�i���t���[��������Missile���쐬���邩")] public float missileTime = 1f;
    private float timer = 0.5f;�@// ���ԃJ�E���g�p�̃^�C�}�[ 0�ɂ���ƁA�J�n����Ɍ����Ă���

    void Update() {
        if (Time.timeScale == 1) {
            if (timer <= 0.0f) {
                GameObject stopGo = Instantiate(stopGoPrefab, transform.position, Quaternion.identity);
                timer = missileTime;
                Destroy(stopGo, 5f);
            }
        }
        if (timer > 0.0f) {
            timer -= Time.deltaTime;
        }
    }
}