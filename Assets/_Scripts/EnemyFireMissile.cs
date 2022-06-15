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
    private int timeCount = 0;
    public Transform enemyTransform;
    public float upperLimit;//敵が弾を撃てるエリア上限
    public float bottomLimit;//敵が弾を撃てるエリア下限
    [Header("ナンフレームおきにMissileを作成するか")]public int missileTime = 600;

    void Update() {
        timeCount += 1;
        if((enemyTransform != null && enemyTransform.position.y <upperLimit && enemyTransform.position.y>bottomLimit)||enemyTransform == null) {
            if (timeCount % missileTime == 0) {
                // 敵のミサイルを生成する
                GameObject enemyMissile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);

                Rigidbody2D enemyMissileRb = enemyMissile.GetComponent<Rigidbody2D>();
                //transform.upは上に向かう、-transform.upは下に向かう
                //自機狙い弾を実装する場合、-transform.upだと自機と180度違う方角に飛んでいく
                enemyMissileRb.velocity = transform.up * speed;

                // ３秒後に敵のミサイルを削除する。
                Destroy(enemyMissile, 3.0f);
            }
        }
    }
}