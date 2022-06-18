using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class Fran : MonoBehaviour
{
    public BossEnemyBullet [] bulletPrefabs;//GameObject型ではない場合、そのままコンポーネントを受け取ることができる。
    GameObject player;
    public AudioClip uh;
    public EnemyHealth furanHealth;
    public GameObject nWay;//自機狙い弾
    public GameObject spiral1;//スパイラル弾
    public GameObject spiral2;//スパイラル弾

    //ランダムにインスタンスを生成する　https://futabazemi.net/notes/unity-randomrange/
    private int number; //ランダム情報を入れるための変数

    void Start() {
        StartCoroutine(CPU());
        player = GameObject.Find("Player");
    }

    void ShotN(int count,float speed)
    {
        int bulletCount = count;
        for(int i =0; i < bulletCount; i++) {
            float angle = i*(2 * Mathf.PI / bulletCount); //2PI:360;
            Shot(angle,speed);
        }
    }

    IEnumerator ShotNCurve(int count, float speed) {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++) {
            float angle = i * (2 * Mathf.PI / bulletCount); //2PI:360;
            Shot(angle - Mathf.PI/2f, speed);
            Shot(-angle - Mathf.PI / 2f, speed);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator CPU() {

        //特定の位置まで移動する
        while (transform.position.y > 2.5f) {
                transform.position -= new Vector3(0, 3, 0) * Time.deltaTime;
                yield return null;//1フレーム待つ
        }

        AudioSource.PlayClipAtPoint(uh, Camera.main.transform.position);

        //whileがtrueならループ
        while (true) {
            //ルーミアのHPが最大HPの2/3以上の場合
            if (furanHealth.currentHP > furanHealth.maxHP * 2 / 3) {
                spiral1.SetActive(true);
                yield return new WaitForSeconds(0.4f);
                spiral2.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                nWay.SetActive(true);

                //ルーミアのHPが最大HPの1/3以上の場合
            } else if (furanHealth.currentHP > furanHealth.maxHP * 1 / 3) {
                nWay.SetActive(false);
                yield return WaveNPlayerAimShot(10, 4);
                yield return new WaitForSeconds(0.9f);
                yield return WaveNPlayerAimShot(8, 5);
                yield return new WaitForSeconds(0.9f);
            } else {
                yield return WaveNShotM(3, 16);
                yield return new WaitForSeconds(0.1f);
                yield return WaveNShotM(3, 17);
                yield return new WaitForSeconds(0.1f);
                yield return WaveNShotM(3, 18);
                yield return new WaitForSeconds(0.1f);
                yield return WaveNShotM(3, 19);
                yield return new WaitForSeconds(0.1f);
                yield return WaveNShotM(3, 20);
                yield return new WaitForSeconds(0.1f);
            }
            //yield return new WaitForSeconds(1.5f);//これが最後に入らない状態でwhileを回すと無限ループになる
        }
    }

    IEnumerator WaveNShotM(int n,int m) {

        //n回、m方向に撃つ
        for (int w = 0; w < n; w++) {
            ShotN(m, 3);
            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator WaveNPlayerAimShot(int n, int m) {

        //n回、m方向に撃つ
        for (int w = 0; w < n; w++) {
            PlayerAimShot(m, 3);
            yield return new WaitForSeconds(0.3f);
        }
    }

    void Shot(float angle,float speed)
    {
        number = UnityEngine.Random.Range(0, bulletPrefabs.Length);
        BossEnemyBullet bullet = Instantiate(bulletPrefabs[number], transform.position, transform.rotation);
        bullet.Setting(angle,speed);
    }

    void PlayerAimShot(int count, float speed) {

        //この弾幕前にplayerが倒されていたら何もしない

        if (player != null) {

            // 自分からみたPlayerの位置を計算する

            Vector3 diffPosition = player.transform.position - transform.position;

            // 自分から見たPlayerの角度を出す：傾きから角度を出す：アークタンジェントを使う

            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);

            int bulletCount = count;

            for (int i = 0; i < bulletCount; i++) {

                float angle = (i - bulletCount / 2f) * ((Mathf.PI / 2f) / bulletCount); // PI/2f：90

                Shot(angleP + angle, speed);

            }

        }

    }
}
