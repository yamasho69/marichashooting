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
    private int timeCount = 0;
    public Transform enemyTransform;
    public float upperLimit;//�G���e�����Ă�G���A���
    public float bottomLimit;//�G���e�����Ă�G���A����
    [Header("�i���t���[��������Missile���쐬���邩")]public int missileTime = 600;

    void Update() {
        timeCount += 1;
        if((enemyTransform != null && enemyTransform.position.y <upperLimit && enemyTransform.position.y>bottomLimit)||enemyTransform == null) {
            if (timeCount % missileTime == 0) {
                // �G�̃~�T�C���𐶐�����
                GameObject enemyMissile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);

                Rigidbody2D enemyMissileRb = enemyMissile.GetComponent<Rigidbody2D>();
                //transform.up�͏�Ɍ������A-transform.up�͉��Ɍ�����
                //���@�_���e����������ꍇ�A-transform.up���Ǝ��@��180�x�Ⴄ���p�ɔ��ł���
                enemyMissileRb.velocity = transform.up * speed;

                // �R�b��ɓG�̃~�T�C�����폜����B
                Destroy(enemyMissile, 3.0f);
            }
        }
    }
}