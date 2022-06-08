using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class BossEnemyShip : MonoBehaviour
{
    public BossEnemyBullet bulletPrefab;//GameObject型ではない場合、そのままコンポーネントを受け取ることができる。
    GameObject player;

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
                transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
                yield return null;//1フレーム待つ
        }

        //カッコの中がtrueの間、繰り返し処理をする
        while (true) {
            yield return WaveNPlayerAimShot(4, 6);
            yield return new WaitForSeconds(1f);
            yield return ShotNCurve(20, 3);
            yield return new WaitForSeconds(1f);
            yield return WaveNShotM(2, 16);
            yield return new WaitForSeconds(1f);
            yield return ShotNCurve(12, 3);
            yield return new WaitForSeconds(1f);
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
        BossEnemyBullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
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
