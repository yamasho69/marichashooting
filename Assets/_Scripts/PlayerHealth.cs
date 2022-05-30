using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class PlayerHealth : MonoBehaviour {
    public GameObject effectPrefab;
    //public AudioClip damageSound;
    private AudioClip destroySound;
    // ★改良（最大HP）
    // 「public」を「private」に変更
    // maxHPを設定（HPの最大値は自由に設定）
    private int playerHP;
    private int maxHP = 1;

    
    // ★追加
    //public Slider hpSlider;
    // ★（追加）
    // 配列の定義（「複数のデータ」を入れることのできる「仕切り」付きの箱を作る）
    public GameObject[] playerIcons;

    // ★（追加）
    // プレーヤーが破壊された回数のデータを入れる箱
    // ★修正
    public static int destroyCount = 0;

    [Header("この回数破壊されたらゲームオーバー")]public int gameOverDestroyCount;

    // ★追加（無敵）
    public bool isMuteki = false;

    float alpha_Sin;
    private Color _color;

    [Header("やられvoice")][SerializeField] AudioClip[] clips;
    //[SerializeField] AudioSource source;

    // ★追加
    private void Start() {
        // ★追加
        // この１行を追加しないと、残機数データと残機数の表示（アイコン数）がずれてしまう。
        UpdatePlayerIcons();

        // ★改良（最大HP）
        playerHP = maxHP;
        // スライダーの最大値の設定
        //hpSlider.maxValue = playerHP;

        // スライダーの現在値の設定
        //hpSlider.value = playerHP;
    }

    private void Update() {
        alpha_Sin = Mathf.Sin(Time.time*30) / 2 + 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // ★追加（無敵）
        // 条件文の中に「&& isMuteki == false」を追加
        if (other.gameObject.CompareTag("EnemyMissile") && isMuteki == false) {
            playerHP -= 1;
            //AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position);

            Destroy(other.gameObject);

            // ★追加
            // スライダーの現在値
            //hpSlider.value = playerHP;

            if (playerHP == 0) {
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                destroySound = GetRandom(clips);
                AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
                Destroy(effect, 1.0f);
                this.gameObject.SetActive(false);
                // ★（追加）
                // HPが０になったら破壊された回数を１つ増加させる。
                destroyCount += 1;

                // ★（追加）
                // 命令ブロック（メソッド）を呼び出す。
                UpdatePlayerIcons();

                // ★★★（追加）
                // 破壊された回数によって場合分けを行います。
                if (destroyCount < gameOverDestroyCount) // ここの条件は自分のゲームに合わせましょう！
                {
                    // リトライ
                    Invoke("Retry", 1.0f);
                } else {
                    // ゲームオーバー
                    Invoke("GameOver", 1.0f);

                    // destroyCountをリセット
                    destroyCount = 0;
                }
            }
        }
    }
    void GameOver() {
        SceneManager.LoadScene("GameOver");
    }

    // ★（追加）
    // プレーヤーの残機数を表示する命令ブロック（メソッド）
    void UpdatePlayerIcons() {
        // for文（繰り返し文）・・・まずは基本形を覚えましょう！
        for (int i = 0; i < playerIcons.Length; i++) {
            if (destroyCount <= i) {
                playerIcons[i].SetActive(true);
            } else {
                playerIcons[i].SetActive(false);
            }
        }
    }

    // ★★（追加）
    // ゲームリトライに関する命令ブロック
    void Retry() {
        this.gameObject.SetActive(true);
        // ★改良（最大HP）
        playerHP = maxHP;
        //hpSlider.value = playerHP;
        // ★追加（無敵）
        // 何秒間無敵状態にするかは自由！
        isMuteki = true;
        StartCoroutine("ColorCoroutine");
        Invoke("MutekiOff", 1.5f);

    }

    // ★追加（無敵）
    void MutekiOff() {
        isMuteki = false;
        StopCoroutine("ColorCoroutine");
        Color _color = GetComponent<Renderer>().material.color;

        _color.a = 1;
        GetComponent<Renderer>().material.color = _color;
    }

    // ★追加（HP回復アイテム）
    // 「public」を付けること（ポイント）
    public void AddHP(int amount) {
        // 「amount」分だけHPを回復させる
        playerHP += amount;

        // 最大HP以上には回復しないようにする。
        if (playerHP > maxHP) {
            playerHP = maxHP;
        }

        // HPスライダー
        //hpSlider.value = playerHP;
    }
    // ★追加（自機1UPアイテム）
    // 「public」を付けること（ポイント）
    public void Player1UP(int amount) {
        // amount分だけ自機の残機を回復させる。
        // （考え方）破壊された回数（「destroyCount」）をamount分だけ減少させる。
        destroyCount -= amount;

        // 最大残機数を超えないようにする（破壊された回数が０未満にならないようにする）
        if (destroyCount < 0) {
            destroyCount = 0;
        }

        // 残機数を表示するアイコン
        UpdatePlayerIcons();
    }

    IEnumerator ColorCoroutine() {
        while (true) {
            yield return new WaitForEndOfFrame();

            Color _color = GetComponent<Renderer>().material.color;

            _color.a = alpha_Sin;

            GetComponent<Renderer>().material.color = _color;
        }
    }

    internal static T GetRandom<T>(params T[] Params) {
        return Params[UnityEngine.Random.Range(0, Params.Length)];
    }
}
