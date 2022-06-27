using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class EnemyFireMissile : MonoBehaviour {
    public GameObject enemyMissilePrefab;
    public float speed;
    //private int timeCount = 0;
    public Transform enemyTransform;
    public float upperLimit;//�G���e�����Ă�G���A���
    public float bottomLimit;//�G���e�����Ă�G���A����
    [Header("�i���t���[��������Missile���쐬���邩")] public float missileTime;
    private float timer = 0.5f;�@// ���ԃJ�E���g�p�̃^�C�}�[ 0�ɂ���ƁA�J�n����Ɍ����Ă���

    void Update() {
        if (Time.timeScale == 1) {
            if ((enemyTransform != null && enemyTransform.position.y < upperLimit && enemyTransform.position.y > bottomLimit) || enemyTransform == null) {
                if (timer <= 0.0f) {
                    // �G�̃~�T�C���𐶐�����
                    GameObject enemyMissile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);

                    Rigidbody2D enemyMissileRb = enemyMissile.GetComponent<Rigidbody2D>();
                    //transform.up�͏�Ɍ������A-transform.up�͉��Ɍ�����
                    //���@�_���e����������ꍇ�A-transform.up���Ǝ��@��180�x�Ⴄ���p�ɔ��ł���
                    enemyMissileRb.velocity = transform.up * speed;
                    timer = missileTime;
                    // �R�b��ɓG�̃~�T�C�����폜����B
                    Destroy(enemyMissile, 3.0f);
                }
            }
            if (timer > 0.0f) {
                timer -= Time.deltaTime;
            }
        }
    }
}