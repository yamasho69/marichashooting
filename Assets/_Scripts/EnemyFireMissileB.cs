using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireMissileB : MonoBehaviour {
    public GameObject enemyMissilePrefab;
    public float speed;
    //private int timeCount;
    public Rotate rotate;
    [Header("速射弾への切り替え")]public bool sokushaOn;
    [Header("ナンフレームおきにMissileを作成するか")] public float missileTime = 1f;
    private float timer = 0.5f;　// 時間カウント用のタイマー 0にすると、開始直後に撃ってくる
    private int shotCount;

    private void Start() {
        Rotate rotate = GetComponent<Rotate>();
    }

    void Update() {
        if (Time.timeScale == 1) {
            //timeCount += 1;

            // 発射間隔を短くする。
            // 「%」と「==」の意味を復習しましょう！（ポイント）
            if (/*timeCount % 80 == 0*/timer <= 0.0f) {
                //アタッチしている発射口のRotation.zの値を変えることで、発射角を変更可
                GameObject missile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);
                Rigidbody2D missileRb = missile.GetComponent<Rigidbody2D>();
                missileRb.velocity = -transform.up * speed;
                timer = missileTime;
                shotCount++;
                // 10秒後に敵のミサイルを削除する。
                Destroy(missile, 2f);
                // ★追加
                // timeCountが500で割り切れる数かつ2000で割り切れない数になった時、このオブジェクトにRotateスクリプトをtrueにする。
                // 同時にRotation Zは5を設定すると綺麗にスパイラルになる。
                if (shotCount % 6 == 0 && shotCount % 24 != 0) {
                    rotate.enabled = true;

                }

                //timeCountが2000で割り切れる数になった時、速射弾に切り替わる。
                if (shotCount % 18 == 0 && sokushaOn) {
                    rotate.enabled = false;
                }

            }
            if (timer > 0.0f) {
                timer -= Time.deltaTime;
            }
        }
    }
}