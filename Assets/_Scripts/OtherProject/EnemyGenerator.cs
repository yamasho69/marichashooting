using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject BossEnemyPrefab;
    [Header("�G�𐶐�����X�p��")]public float enemySpawnspan;
    [Header("�{�X�͉��b��ɏo�Ă��邩")]public float bossSpawnTime;
    void Start() {
        InvokeRepeating("Spawn", 2f, 0.5f);�@//Spawn�֐����A2�b���0.5�b���݂Ŏ��s����B
        if (bossSpawnTime != 0f) {//bossSpawnTime��0�łȂ����
            Invoke("BossSpawn", bossSpawnTime);//bossSpawnTime���boss�𐶐�
        }
    }

    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-3f, 3f),
            transform.position.y,
            transform.position.z);
        Instantiate
            (enemyPrefab,//��������I�u�W�F�N�g
            spawnPosition,//��������ʒu
            transform.rotation);//�������̌���
    }

    void BossSpawn() {
        Instantiate
            (BossEnemyPrefab,//��������I�u�W�F�N�g
            transform.position,//��������ʒu
            transform.rotation);//�������̌���
        CancelInvoke();// InvokeRepeating���~�߂�
    }
}
