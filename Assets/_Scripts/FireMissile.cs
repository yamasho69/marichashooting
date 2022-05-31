using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class FireMissile : MonoBehaviour {
    // �ϐ��̒�`�i�f�[�^�����邽�߂̔����쐬����B�j
    public GameObject missilePrefab;
    public float missileSpeed;
    public AudioSource sfxSource;
    [Header("���Ȃ�SE")] public AudioClip[] onaraSE;
    // �����ǁi�������A�ˁj
    private int timeCount;

    // ���ǉ��i�e�؂ꔭ���j
    // �����ǁi�V���b�g�p���[�̑S�񕜁j
    // �A�N�Z�X�C���q���upublic�v�ɕύX����B
    public float maxPower = 2600;
    public float shotPower;

    // ���ǉ��i�p���[�c�ʂ̕\���j
    public Slider powerSlider;

    private void Start() {
        shotPower = maxPower;

        // ���ǉ��i�p���[�c�ʂ̕\���j
        powerSlider.maxValue = maxPower;
        powerSlider.value = shotPower;
    }


    void Update() {
        // �����ǁi�������A�ˁj
        timeCount += 1;

        // �����ǁi�������A�ˁj
        // �uGetButtonDown�v���uGetButton�v�ɕύX����i�|�C���g�j
        // �uGetButton�v�́u�����Ă���ԁv�Ƃ����Ӗ�
        if (Input.GetButton("Jump")) {

            // ���ǉ��i�e�؂ꔭ���j
            // �����̃��W�b�N���悭���K���邱�Ɓi�d�v�|�C���g�j
            if (shotPower <= 0) {
                return;
            }

            // ���ǉ��i�e�؂ꔭ���j
            shotPower -= 1;

            // ���ǉ��i�p���[�c�ʂ̕\���j
            powerSlider.value = shotPower;


            // �����ǁi�������A�ˁj
            // �u5�v�̕����̐�����ς���Ɓu�A�˂̊Ԋu�v��ύX���邱�Ƃ��ł��܂��i�|�C���g�j
            // �u%�v�Ɓu==�v�̈Ӗ������𕜏K���܂��傤�B
            if (timeCount % 130 == 0) {
                // �v���n�u����~�T�C���I�u�W�F�N�g���쐬���A�����missile�Ƃ������O�̔��ɓ����B
                GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);

                Rigidbody2D rigidbody2D = missile.GetComponent<Rigidbody2D>();

                rigidbody2D.velocity = transform.up * missileSpeed;

                RandomizeSfx(onaraSE);

                // ���˂����~�T�C�����Q�b��ɔj��i�폜�j����B
                Destroy(missile, 2.0f);
            }
        }
        // ���ǉ��i�V���b�g�p���[�̉񕜁j
        else {
            shotPower += 0.5f;

            if (shotPower > maxPower) {
                shotPower = maxPower;
            }

            powerSlider.value = shotPower;
        }
    }

    public void RandomizeSfx(params AudioClip[] clips) {
        var randomIndex = UnityEngine.Random.Range(0, clips.Length);
        sfxSource.PlayOneShot(clips[randomIndex]);
    }
}
