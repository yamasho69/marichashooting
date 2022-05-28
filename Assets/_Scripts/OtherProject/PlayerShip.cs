using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class PlayerShip : MonoBehaviour {
    public Transform firePoint; //弾を発射する位置
    public GameObject bulletPrefab;
    AudioSource audioSource;
    public AudioClip shotSE;
    GameController gameController;
    public GameObject explosion; //破壊エフェクト

    void Start() {
        audioSource = GetComponent<AudioSource>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update() {

        Move();
        Shot();

    }

    void Shot() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            audioSource.PlayOneShot(shotSE);
        }
    }

    void Move() {
        float x = Input.GetAxisRaw("Horizontal");//GetAxisRawだとすぐ動き、すぐ停まる機敏な動きに変わる
        float y = Input.GetAxisRaw("Vertical");
        Vector3 nextPosition = transform.position + new Vector3(x,y,0) * Time.deltaTime * 4f;
        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x, -6.5f, 6.5f),//nextPosition.xを第二引数と第三引数以内に制限できる。
            Mathf.Clamp(nextPosition.y, -3.3f, 3.3f),
            nextPosition.z
            );
        transform.position = nextPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Bullet") == true) {
            return;//この関数に関してはここで実行を終える。
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);//gameObjectはこのスクリプトをアタッチしているオブジェクトのこと
        Destroy(collision.gameObject);//collision.gameObjectはこのスクリプトをアタッチしているオブジェクトとぶつかったオブジェクトのこと
        gameController.GameOver();
    }
}
