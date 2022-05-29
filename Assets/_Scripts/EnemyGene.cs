using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGene : MonoBehaviour {
    public GameObject enemyPrefab;
    public float speed;
    [Header("敵を生み出す回数")] public int spawnCount;
    [Header("一度に敵を生み出す回数")] public int oneSpawn;
    [Header("生み出す間隔")] public float spawnSpan;
    [Header("一匹一匹の間隔")] public float spawnInterval;
    [Header("消えるまでの秒数")] public float destroyTime;

    private void Start() {
        StartCoroutine(GeneEnemy());
    }

    // （ポイント）コルーチン
    IEnumerator GeneEnemy() {
        // 何回繰り返すかは自由に設定
        for (int j = 0; j < spawnCount; j++) {
            for (int i = 0; i < oneSpawn; i++) {
                GameObject enemey = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(0, 0, 0));//回転をつけないように変更
                Rigidbody2D enemyRb = enemey.GetComponent<Rigidbody2D>();//2Dに変更
                enemyRb.velocity = transform.up * speed;//テキストから変更
                if (destroyTime != 0) {//destroyTimeが0ならば時間で破壊しない。
                    Destroy(enemey, destroyTime);
                }

                // 0.2秒ごとに動作を繰り返す（自由に変更可能）
                yield return new WaitForSeconds(spawnInterval);
            }

            // 3秒ごとに動作を繰り返す（自由に変更可能）
            yield return new WaitForSeconds(spawnSpan);
        }
    }
}