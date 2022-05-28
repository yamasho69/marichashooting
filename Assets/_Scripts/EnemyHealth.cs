using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class EnemyHealth : MonoBehaviour {
    public GameObject effectPrefab;
    public AudioClip sound;
    public int enemyHP;
    public Slider hpSlider;
    // �����ǉ��i�X�R�A�j
    public int scoreValue;
    private ScoreManager sm;

    private void Start() {
        // �X���C�_�[�̍ő�l�̐ݒ�
        hpSlider.maxValue = enemyHP;

        // �X���C�_�[�̌��ݒl�̐ݒ�
        hpSlider.value = enemyHP;

        // �����ǉ��i�X�R�A�j
        // �uScoreLabel�v�I�u�W�F�N�g�ɂ��Ă���uScoreManager�v�X�N���v�g�ɃA�N�Z�X���Ď擾����i�|�C���g�j
        sm = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();
    }


    private void OnTriggerEnter2D(Collider2D other) {
        // �������Ԃ���������ɁuMissile�v�Ƃ����^�O�iTag�j�����Ă�����A
        if (other.gameObject.CompareTag("Missile")) {
            // �G��HP���P������������
            enemyHP -= 1;

            // �~�T�C����j�󂷂�
            Destroy(other.gameObject);

            // ���ǉ�
            // �X���C�_�[�̌��ݒl
            hpSlider.value = enemyHP;

            // �G��HP���O�ɂȂ�����G�I�u�W�F�N�g��j�󂷂�B
            if (enemyHP == 0) {
                // �e�I�u�W�F�N�g��j�󂷂�i�|�C���g�G���̎g�������o���悤�I�j
                Destroy(transform.root.gameObject);

                // ���ʉ����o��
                AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position,0.1f);

                // �G�t�F�N�g�𔭐�������
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

                // 0.5�b��ɃG�t�F�N�g������
                Destroy(effect, 2.0f);
                // �����ǉ��i�X�R�A�j
                // �G��j�󂵂��u�ԂɃX�R�A�����Z���郁�\�b�h���Ăяo���B
                // �����ɂ́uscoreValue�v������B
                sm.AddScore(scoreValue);
            }
        }
    }
}
