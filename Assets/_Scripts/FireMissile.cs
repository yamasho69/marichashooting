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

    void Update() {
        // �����ǁi�������A�ˁj
        timeCount += 1;

        // �����ǁi�������A�ˁj
        // �uGetButtonDown�v���uGetButton�v�ɕύX����i�|�C���g�j
        // �uGetButton�v�́u�����Ă���ԁv�Ƃ����Ӗ�
        if (Input.GetButton("Jump")) {
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
    }

    public void RandomizeSfx(params AudioClip[] clips) {
        var randomIndex = UnityEngine.Random.Range(0, clips.Length);
        sfxSource.PlayOneShot(clips[randomIndex]);
    }
}
