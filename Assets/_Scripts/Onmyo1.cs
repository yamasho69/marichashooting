using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class Onmyo1 : MonoBehaviour
{
    public BossEnemyBullet bulletPrefab;//GameObject�^�ł͂Ȃ��ꍇ�A���̂܂܃R���|�[�l���g���󂯎�邱�Ƃ��ł���B
    GameObject player;
    public GameObject stopGo;

    void Start() {
        StartCoroutine(CPU());
        player = GameObject.Find("Player");
    }

    //�A�N�e�B�u�ɂȂ�Ƃ�x���W�̓����_���ɂ���B
    private void OnEnable() {
        //https://www.sejuku.net/blog/51251
        Transform myTransform = this.transform;
        // ���W���擾
        Vector3 pos = myTransform.position;
        pos.x = UnityEngine.Random.Range(-2.0f, 2.0f);
        pos.y = 7f;
        myTransform.position = pos;  // ���W��ݒ�
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
                transform.position -= new Vector3(0, 5, 0) * Time.deltaTime;
                yield return null;//1�t���[���҂�
        }

        //�J�b�R�̒���true�̊ԁA�J��Ԃ�����������
        while (true) {
            stopGo.SetActive(true);
            yield return new WaitForSeconds(6f);
            stopGo.SetActive(false);
            yield return WaveNPlayerAimShot(3, 5);
            yield return new WaitForSeconds(2f);
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
        BossEnemyBullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
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
