using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class FireMissile : MonoBehaviour {
    // 変数の定義（データを入れるための箱を作成する。）
    public GameObject missilePrefab;
    public float missileSpeed;
    public AudioSource sfxSource;
    [Header("おならSE")] public AudioClip[] onaraSE;
    // ★改良（長押し連射）
    private int timeCount;

    // ★追加（弾切れ発生）
    // ★改良（ショットパワーの全回復）
    // アクセス修飾子を「public」に変更する。
    public float maxPower = 2600;
    public float shotPower;

    // ★追加（パワー残量の表示）
    public Slider powerSlider;

    private void Start() {
        shotPower = maxPower;

        // ★追加（パワー残量の表示）
        powerSlider.maxValue = maxPower;
        powerSlider.value = shotPower;
    }


    void Update() {
        // ★改良（長押し連射）
        timeCount += 1;

        // ★改良（長押し連射）
        // 「GetButtonDown」を「GetButton」に変更する（ポイント）
        // 「GetButton」は「押している間」という意味
        if (Input.GetButton("Jump")) {

            // ★追加（弾切れ発生）
            // ここのロジックをよく復習すること（重要ポイント）
            if (shotPower <= 0) {
                return;
            }

            // ★追加（弾切れ発生）
            shotPower -= 1;

            // ★追加（パワー残量の表示）
            powerSlider.value = shotPower;


            // ★改良（長押し連射）
            // 「5」の部分の数字を変えると「連射の間隔」を変更することができます（ポイント）
            // 「%」と「==」の意味合いを復習しましょう。
            if (timeCount % 130 == 0) {
                // プレハブからミサイルオブジェクトを作成し、それをmissileという名前の箱に入れる。
                GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);

                Rigidbody2D rigidbody2D = missile.GetComponent<Rigidbody2D>();

                rigidbody2D.velocity = transform.up * missileSpeed;

                RandomizeSfx(onaraSE);

                // 発射したミサイルを２秒後に破壊（削除）する。
                Destroy(missile, 2.0f);
            }
        }
        // ★追加（ショットパワーの回復）
        else {
            shotPower += 0.5f;

            if (shotPower > maxPower) {
                shotPower = maxPower;
            }

            powerSlider.value = shotPower;
        }
    }

    public void RandomizeSfx(params AudioClip[] clips) {
        var randomIndex = UnityEngine.Random.Range(0, clips.Length);
        sfxSource.PlayOneShot(clips[randomIndex]);
    }
}
