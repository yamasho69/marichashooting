using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class Rumia : MonoBehaviour
{
    public BossEnemyBullet [] bulletPrefabs;//GameObject�^�ł͂Ȃ��ꍇ�A���̂܂܃R���|�[�l���g���󂯎�邱�Ƃ��ł���B
    GameObject player;
    public AudioClip sonanoka;
    public EnemyHealth rumiaHealth;

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

        AudioSource.PlayClipAtPoint(sonanoka, Camera.main.transform.position);

        //while��true�Ȃ烋�[�v
        while (true) {
            //���[�~�A��HP���ő�HP��2/3�ȏ�̏ꍇ
            if (rumiaHealth.currentHP > rumiaHealth.maxHP * 2 / 3) {
                yield return WaveNPlayerAimShot(5, 3);
                yield return new WaitForSeconds(1f);
                yield return WaveNPlayerAimShot(6, 3);
                yield return new WaitForSeconds(1f);
            //���[�~�A��HP���ő�HP��1/3�ȏ�̏ꍇ
            } else if (rumiaHealth.currentHP > rumiaHealth.maxHP * 1 / 3) {
                yield return WaveNPlayerAimShot(6, 4);
                yield return new WaitForSeconds(0.9f);
                yield return WaveNPlayerAimShot(7, 5);
                yield return new WaitForSeconds(0.9f);
            } else {
                yield return WaveNShotM(4, 10);
                yield return new WaitForSeconds(0.7f);
            }
            //yield return new WaitForSeconds(1.5f);//���ꂪ�Ō�ɓ���Ȃ���Ԃ�while���񂷂Ɩ������[�v�ɂȂ�
        }
    }

    IEnumerator WaveNShotM(int n,int m) {

        //n��Am�����Ɍ���
        for (int w = 0; w < n; w++) {
            ShotN(m, 3);
            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator WaveNPlayerAimShot(int n, int m) {

        //n��Am�����Ɍ���
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
