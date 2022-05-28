using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class EnemyShip : MonoBehaviour
{
    public GameObject explosion; //破壊エフェクト
    //GameController gameController;
    public GameObject bulletPrefab;

    float offset;//揺れにランダム性を持たせるために初期のポジションが必要
    void Start()
    {
        offset = UnityEngine.Random.Range(0, 2f * Mathf.PI);//0から 2f * Mathf.PIの間で始めのポジションをランダムに
        InvokeRepeating("Shot", 2f, 1f);//Shot関数を2秒後から、1秒間隔で実行
        //gameController = GameObject.Find("GameController").GetComponent<GameController>();        
    }

    void Update()
    {
        transform.position -= new Vector3(
            Mathf.Cos(Time.frameCount * 0.008f+offset) * 0.01f,//横揺れ
            2 * Time.deltaTime, 
            0) ;
        if(transform.position.y < -5) {
            Destroy(gameObject);
        }
    }

    void Shot() {
        Instantiate(bulletPrefab,transform.position,transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player") == true) {
            Instantiate(explosion, collision.transform.position, transform.rotation);
            //gameController.GameOver();
        } else if(collision.CompareTag("Bullet") == true) {
            //gameController.AddScore();
        }else if (collision.CompareTag("EnemyBullet") == true) {
            return;//この関数に関してはここで実行を終える。
        } else if (collision.CompareTag("BossEnemy") == true) {
            return;//この関数に関してはここで実行を終える。
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);//gameObjectはこのスクリプトをアタッチしているオブジェクトのこと
        Destroy(collision.gameObject);//collision.gameObjectはこのスクリプトをアタッチしているオブジェクトとぶつかったオブジェクトのこと
    }
}
