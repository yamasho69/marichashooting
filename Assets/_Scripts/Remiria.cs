using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class Remiria : MonoBehaviour
{
    //public BossEnemyBullet [] bulletPrefabs;//GameObject型ではない場合、そのままコンポーネントを受け取ることができる。
    public BossEnemyBullet big;
    public BossEnemyBullet redSword;
    public BossEnemyBullet blueSword;
    GameObject player;
    public AudioClip uh;
    public EnemyHealth remiriaHealth;
    public GameObject nWay;//自機狙い弾
    public GameObject spiral;//スパイラル弾

    public enum BulletType {
        Big,
        RedSword,
        BlueSword
    }
    private BulletType bulletType;

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
            //レミリアのHPが最大HPの2/3以上の場合
            if (remiriaHealth.currentHP > remiriaHealth.maxHP * 2 / 3) {
                bulletType = BulletType.Big;
                yield return WaveNShotM(8, 16);
                yield return new WaitForSeconds(1f);
                bulletType = BulletType.BlueSword;
                yield return WaveNPlayerAimShot(10, 5);
                yield return new WaitForSeconds(1.8f);
            //レミリアのHPが最大HPの1/3以上の場合
            } else if (remiriaHealth.currentHP > remiriaHealth.maxHP * 1 / 3) {
                nWay.SetActive(true);
                spiral.SetActive(false);
                yield return new WaitForSeconds(1.2f);
                spiral.SetActive(true);
                nWay.SetActive(false);
                yield return new WaitForSeconds(4f);
            } else {
                bulletType = BulletType.Big;
                nWay.SetActive(false);
                spiral.SetActive(false);
                yield return WaveNPlayerAimShot(6, 7);
                yield return new WaitForSeconds(1.5f);
            }
            //yield return new WaitForSeconds(1.5f);//これが最後に入らない状態でwhileを回すと無限ループになる
        }
    }

    IEnumerator WaveNShotM(int n,int m) {

        //n回、m方向に撃つ
        for (int w = 0; w < n; w++) {
            ShotN(m, 4);
            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator WaveNPlayerAimShot(int n, int m) {

        //n回、m方向に撃つ
        for (int w = 0; w < n; w++) {
            PlayerAimShot(m, 7);
            yield return new WaitForSeconds(0.3f);
        }
    }

    void Shot(float angle, float speed) {
        switch (bulletType) { 
            case BulletType.RedSword:
                BossEnemyBullet bulletr = Instantiate(redSword, transform.position, transform.rotation);
                bulletr.Setting(angle, speed);
                break;
            case BulletType.BlueSword:
                BossEnemyBullet bulletb = Instantiate(blueSword, transform.position, transform.rotation);
                bulletb.Setting(angle, speed);
                break;
            case BulletType.Big:
                BossEnemyBullet bulletg = Instantiate(big, transform.position, transform.rotation);
                bulletg.Setting(angle, speed);
                break;
        }
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
