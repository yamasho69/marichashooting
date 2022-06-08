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
    private AudioClip destroySound;
    public static int zanki = 3;

    // ★追加（ショットパワーの全回復）
    public FireMissile fireMissile;

    // ★追加（無敵）
    public bool isMuteki = false;
    public float mutekiTime;

    float alpha_Sin;
    private Color _color;

    [Header("やられvoice")][SerializeField] AudioClip[] clips;


    private void Update() {
        alpha_Sin = Mathf.Sin(Time.time*30) / 2 + 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // ★追加（無敵）
        // 条件文の中に「&& isMuteki == false」を追加
        if (other.gameObject.CompareTag("EnemyMissile") && isMuteki == false) {
            //Destroy(other.gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            destroySound = GetRandom(clips);
            AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
            Destroy(effect, 1.0f);
            this.gameObject.SetActive(false);
            zanki--;
            Debug.Log(zanki);

            // ★★★（追加）
            // 破壊された回数によって場合分けを行います。
            if (zanki >= 0) // ここの条件は自分のゲームに合わせましょう！
            {
                // リトライ
                Invoke("Retry", 1.0f);
            } else {
                // ゲームオーバー
                Invoke("GameOver", 1.0f);
            }
        }
    }
    void GameOver() {
        SceneManager.LoadScene("GameOver");
    }
    // ★★（追加）
    // ゲームリトライに関する命令ブロック
    void Retry() {
        this.gameObject.SetActive(true);
        // ★追加（無敵）
        // 何秒間無敵状態にするかは自由！
        isMuteki = true;
        StartCoroutine("ColorCoroutine");
        Invoke("MutekiOff", mutekiTime);

        // ★追加（ショットパワーの全回復）
        fireMissile.shotPower = fireMissile.maxPower;
    }

    // ★追加（無敵）
    void MutekiOff() {
        isMuteki = false;
        StopCoroutine("ColorCoroutine");
        Color _color = GetComponent<Renderer>().material.color;

        _color.a = 1;
        GetComponent<Renderer>().material.color = _color;
    }

    // ★追加（自機1UPアイテム）
    // 「public」を付けること（ポイント）
    public void Player1UP(int amount) {
        if (zanki < 99) {
            zanki++;
        }
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
