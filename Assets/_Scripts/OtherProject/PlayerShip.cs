using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class PlayerShip : MonoBehaviour {
    public Transform firePoint; //�e�𔭎˂���ʒu
    public GameObject bulletPrefab;
    AudioSource audioSource;
    public AudioClip shotSE;
    GameController gameController;
    public GameObject explosion; //�j��G�t�F�N�g

    void Start() {
        audioSource = GetComponent<AudioSource>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update() {

        Move();
        Shot();

    }

    void Shot() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            audioSource.PlayOneShot(shotSE);
        }
    }

    void Move() {
        float x = Input.GetAxisRaw("Horizontal");//GetAxisRaw���Ƃ��������A������܂�@�q�ȓ����ɕς��
        float y = Input.GetAxisRaw("Vertical");
        Vector3 nextPosition = transform.position + new Vector3(x,y,0) * Time.deltaTime * 4f;
        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x, -6.5f, 6.5f),//nextPosition.x��������Ƒ�O�����ȓ��ɐ����ł���B
            Mathf.Clamp(nextPosition.y, -3.3f, 3.3f),
            nextPosition.z
            );
        transform.position = nextPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Bullet") == true) {
            return;//���̊֐��Ɋւ��Ă͂����Ŏ��s���I����B
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);//gameObject�͂��̃X�N���v�g���A�^�b�`���Ă���I�u�W�F�N�g�̂���
        Destroy(collision.gameObject);//collision.gameObject�͂��̃X�N���v�g���A�^�b�`���Ă���I�u�W�F�N�g�ƂԂ������I�u�W�F�N�g�̂���
        gameController.GameOver();
    }
}
