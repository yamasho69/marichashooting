using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class EnemyShip : MonoBehaviour
{
    public GameObject explosion; //�j��G�t�F�N�g
    //GameController gameController;
    public GameObject bulletPrefab;

    float offset;//�h��Ƀ����_�������������邽�߂ɏ����̃|�W�V�������K�v
    void Start()
    {
        offset = UnityEngine.Random.Range(0, 2f * Mathf.PI);//0���� 2f * Mathf.PI�̊ԂŎn�߂̃|�W�V�����������_����
        InvokeRepeating("Shot", 2f, 1f);//Shot�֐���2�b�ォ��A1�b�Ԋu�Ŏ��s
        //gameController = GameObject.Find("GameController").GetComponent<GameController>();        
    }

    void Update()
    {
        transform.position -= new Vector3(
            Mathf.Cos(Time.frameCount * 0.008f+offset) * 0.01f,//���h��
            2 * Time.deltaTime, 
            0) ;
        if(transform.position.y < -5) {
            Destroy(gameObject);
        }
    }

    void Shot() {
        Instantiate(bulletPrefab,transform.position,transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player") == true) {
            Instantiate(explosion, collision.transform.position, transform.rotation);
            //gameController.GameOver();
        } else if(collision.CompareTag("Bullet") == true) {
            //gameController.AddScore();
        }else if (collision.CompareTag("EnemyBullet") == true) {
            return;//���̊֐��Ɋւ��Ă͂����Ŏ��s���I����B
        } else if (collision.CompareTag("BossEnemy") == true) {
            return;//���̊֐��Ɋւ��Ă͂����Ŏ��s���I����B
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);//gameObject�͂��̃X�N���v�g���A�^�b�`���Ă���I�u�W�F�N�g�̂���
        Destroy(collision.gameObject);//collision.gameObject�͂��̃X�N���v�g���A�^�b�`���Ă���I�u�W�F�N�g�ƂԂ������I�u�W�F�N�g�̂���
    }
}
