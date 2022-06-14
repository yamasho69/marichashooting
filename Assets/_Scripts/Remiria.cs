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
    //public BossEnemyBullet [] bulletPrefabs;//GameObject�^�ł͂Ȃ��ꍇ�A���̂܂܃R���|�[�l���g���󂯎�邱�Ƃ��ł���B
    public BossEnemyBullet big;
    public BossEnemyBullet redSword;
    public BossEnemyBullet blueSword;
    GameObject player;
    public AudioClip uh;
    public EnemyHealth remiriaHealth;
    public GameObject nWay;//���@�_���e
    public GameObject spiral;//�X�p�C�����e

    public enum BulletType {
        Big,
        RedSword,
        BlueSword
    }
    private BulletType bulletType;

    //�����_���ɃC���X�^���X�𐶐�����@https://futabazemi.net/notes/unity-randomrange/
    private int number; //�����_���������邽�߂̕ϐ�

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

        //����̈ʒu�܂ňړ�����
        while (transform.position.y > 2.5f) {
                transform.position -= new Vector3(0, 3, 0) * Time.deltaTime;
                yield return null;//1�t���[���҂�
        }

        AudioSource.PlayClipAtPoint(uh, Camera.main.transform.position);

        //while��true�Ȃ烋�[�v
        while (true) {
            //���~���A��HP���ő�HP��2/3�ȏ�̏ꍇ
            if (remiriaHealth.currentHP > remiriaHealth.maxHP * 2 / 3) {
                bulletType = BulletType.Big;
                yield return WaveNShotM(8, 16);
                yield return new WaitForSeconds(1f);
                bulletType = BulletType.BlueSword;
                yield return WaveNPlayerAimShot(10, 5);
                yield return new WaitForSeconds(1.8f);
            //���~���A��HP���ő�HP��1/3�ȏ�̏ꍇ
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
            //yield return new WaitForSeconds(1.5f);//���ꂪ�Ō�ɓ���Ȃ���Ԃ�while���񂷂Ɩ������[�v�ɂȂ�
        }
    }

    IEnumerator WaveNShotM(int n,int m) {

        //n��Am�����Ɍ���
        for (int w = 0; w < n; w++) {
            ShotN(m, 4);
            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator WaveNPlayerAimShot(int n, int m) {

        //n��Am�����Ɍ���
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

        //���̒e���O��player���|����Ă����牽�����Ȃ�

        if (player != null) {

            // ��������݂�Player�̈ʒu���v�Z����

            Vector3 diffPosition = player.transform.position - transform.position;

            // �������猩��Player�̊p�x���o���F�X������p�x���o���F�A�[�N�^���W�F���g���g��

            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);

            int bulletCount = count;

            for (int i = 0; i < bulletCount; i++) {

                float angle = (i - bulletCount / 2f) * ((Mathf.PI / 2f) / bulletCount); // PI/2f�F90

                Shot(angleP + angle, speed);

            }

        }

    }
}
