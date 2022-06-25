using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class EnemyHealth : MonoBehaviour {
    public GameObject effectPrefab;
    public AudioClip sound;
    public int enemyHP;
    public Slider hpSlider;
    // ★★追加（スコア）
    public int scoreValue;
    private ScoreManager sm;

    public GameObject image;
    //最大HP
    public float maxHP;
    //現在のHP
    public float currentHP;

    private void Start() {
        // ★改良（HPスライダー）
        // 動く敵には『HPスライダー』を設置しません。
        // そのためHPスライダーを設置している場合だけスライダーが動作するように改良します。
        if (hpSlider) {
            hpSlider.maxValue = enemyHP;
            hpSlider.value = enemyHP;
        }
        if (image) {
            currentHP = maxHP;
        }

        // ★★追加（スコア）
        // 「ScoreLabel」オブジェクトについている「ScoreManager」スクリプトにアクセスして取得する（ポイント）
        sm = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();
    }


    private void OnTriggerEnter2D(Collider2D other) {
        // もしもぶつかった相手に「Missile」というタグ（Tag）がついていたら、
        if (other.gameObject.CompareTag("Missile")) {
            // 敵のHPを１ずつ減少させる
            if (hpSlider) {
                enemyHP -= 1;
            }
            if (image) {
                currentHP -= 1;
            }

            // ミサイルを破壊する
            Destroy(other.gameObject);

            // ★改良（HPスライダー）
            if (hpSlider) {
                hpSlider.value = enemyHP;//スライダーの現在値
            }

            if (image) {
                HPDown(currentHP, maxHP);
            }

            // 敵のHPが０になったら敵オブジェクトを破壊する。
            if (currentHP==0||enemyHP==0) {
                // 親オブジェクトを破壊する（ポイント；この使い方を覚えよう！）
                //Destroy(transform.root.gameObject);
                //親オブジェクトを破壊するのはキケン
                Destroy(this.gameObject);
                if (sound) {
                    // 効果音を出す
                    AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position,0.8f);
                }
                if (effectPrefab) {
                    // エフェクトを発生させる
                    GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

                    // 0.5秒後にエフェクトを消す
                    Destroy(effect, 2.0f);
                }
                // ★★追加（スコア）
                // 敵を破壊した瞬間にスコアを加算するメソッドを呼び出す。
                // 引数には「scoreValue」を入れる。
                sm.AddScore(scoreValue);
            }
        }
    }

    public void HPDown(float current, float max) {
        //ImageというコンポーネントのfillAmountを取得して操作する
        image.GetComponent<Image>().fillAmount = current / max;
    }
}
