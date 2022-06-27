using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene_StopGo : MonoBehaviour {
    public GameObject stopGoPrefab;
    [Header("ナンフレームおきにMissileを作成するか")] public float missileTime = 1f;
    private float timer = 0.5f;　// 時間カウント用のタイマー 0にすると、開始直後に撃ってくる

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