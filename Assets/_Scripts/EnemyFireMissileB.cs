using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireMissileB : MonoBehaviour {
    public GameObject enemyMissilePrefab;
    public float speed;
    private int timeCount;
    public Rotate rotate;
    [Header("速射弾への切り替え")]public bool sokushaOn;

    private void Start() {
        Rotate rotate = GetComponent<Rotate>();
    }

    void Update() {
        timeCount += 1;

        // 発射間隔を短くする。
        // 「%」と「==」の意味を復習しましょう！（ポイント）
        if (timeCount % 80 == 0) {
            //アタッチしている発射口のRotation.zの値を変えることで、発射角を変更可
            GameObject missile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D missileRb = missile.GetComponent<Rigidbody2D>();
            missileRb.velocity = -transform.up * speed;

            // 10秒後に敵のミサイルを削除する。
            Destroy(missile, 2f);
        }


        // ★追加
        // timeCountが500で割り切れる数かつ2000で割り切れる数でないになった時、このオブジェクトにRotateスクリプトをtrueにする。
        // 同時にRotation Zは5を設定すると綺麗にスパイラルになる。
        if (timeCount % 500 == 0 && timeCount % 2000 != 0) {
            rotate.enabled = true;
            
        }

        //timeCountが2000で割り切れる数になった時、速射弾に切り替わる。
        if (timeCount % 2000 == 0&&sokushaOn) {
            rotate.enabled = false;
        }
    }
}