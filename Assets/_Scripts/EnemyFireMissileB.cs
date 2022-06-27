using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireMissileB : MonoBehaviour {
    public GameObject enemyMissilePrefab;
    public float speed;
    //private int timeCount;
    public Rotate rotate;
    [Header("���˒e�ւ̐؂�ւ�")]public bool sokushaOn;
    [Header("�i���t���[��������Missile���쐬���邩")] public float missileTime = 1f;
    private float timer = 0.5f;�@// ���ԃJ�E���g�p�̃^�C�}�[ 0�ɂ���ƁA�J�n����Ɍ����Ă���
    private int shotCount;

    private void Start() {
        Rotate rotate = GetComponent<Rotate>();
    }

    void Update() {
        if (Time.timeScale == 1) {
            //timeCount += 1;

            // ���ˊԊu��Z������B
            // �u%�v�Ɓu==�v�̈Ӗ��𕜏K���܂��傤�I�i�|�C���g�j
            if (/*timeCount % 80 == 0*/timer <= 0.0f) {
                //�A�^�b�`���Ă��锭�ˌ���Rotation.z�̒l��ς��邱�ƂŁA���ˊp��ύX��
                GameObject missile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);
                Rigidbody2D missileRb = missile.GetComponent<Rigidbody2D>();
                missileRb.velocity = -transform.up * speed;
                timer = missileTime;
                shotCount++;
                // 10�b��ɓG�̃~�T�C�����폜����B
                Destroy(missile, 2f);
                // ���ǉ�
                // timeCount��500�Ŋ���؂�鐔����2000�Ŋ���؂�Ȃ����ɂȂ������A���̃I�u�W�F�N�g��Rotate�X�N���v�g��true�ɂ���B
                // ������Rotation Z��5��ݒ肷����Y��ɃX�p�C�����ɂȂ�B
                if (shotCount % 6 == 0 && shotCount % 24 != 0) {
                    rotate.enabled = true;

                }

                //timeCount��2000�Ŋ���؂�鐔�ɂȂ������A���˒e�ɐ؂�ւ��B
                if (shotCount % 18 == 0 && sokushaOn) {
                    rotate.enabled = false;
                }

            }
            if (timer > 0.0f) {
                timer -= Time.deltaTime;
            }
        }
    }
}