using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class EnemyFireMissile : MonoBehaviour {
    public GameObject enemyMissilePrefab;
    public float speed;
    //private int timeCount = 0;
    public Transform enemyTransform;
    public float upperLimit;//敵が弾を撃てるエリア上限
    public float bottomLimit;//敵が弾を撃てるエリア下限
    [Header("ナンフレームおきにMissileを作成するか")] public float missileTime;
    private float timer = 0.5f;　// 時間カウント用のタイマー 0にすると、開始直後に撃ってくる

    void Update() {
        if (Time.timeScale == 1) {
            if ((enemyTransform != null && enemyTransform.position.y < upperLimit && enemyTransform.position.y > bottomLimit) || enemyTransform == null) {
                if (timer <= 0.0f) {
                    // 敵のミサイルを生成する
                    GameObject enemyMissile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);

                    Rigidbody2D enemyMissileRb = enemyMissile.GetComponent<Rigidbody2D>();
                    //transform.upは上に向かう、-transform.upは下に向かう
                    //自機狙い弾を実装する場合、-transform.upだと自機と180度違う方角に飛んでいく
                    enemyMissileRb.velocity = transform.up * speed;
                    timer = missileTime;
                    // ３秒後に敵のミサイルを削除する。
                    Destroy(enemyMissile, 3.0f);
                }
            }
            if (timer > 0.0f) {
                timer -= Time.deltaTime;
            }
        }
    }
}