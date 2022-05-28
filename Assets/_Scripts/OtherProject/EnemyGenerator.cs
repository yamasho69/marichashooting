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
    [Header("敵を生成するスパン")]public float enemySpawnspan;
    [Header("ボスは何秒後に出てくるか")]public float bossSpawnTime;
    void Start() {
        InvokeRepeating("Spawn", 2f, 0.5f);　//Spawn関数を、2秒後に0.5秒刻みで実行する。
        if (bossSpawnTime != 0f) {//bossSpawnTimeが0でなければ
            Invoke("BossSpawn", bossSpawnTime);//bossSpawnTime後にbossを生成
        }
    }

    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-3f, 3f),
            transform.position.y,
            transform.position.z);
        Instantiate
            (enemyPrefab,//生成するオブジェクト
            spawnPosition,//生成する位置
            transform.rotation);//生成時の向き
    }

    void BossSpawn() {
        Instantiate
            (BossEnemyPrefab,//生成するオブジェクト
            transform.position,//生成する位置
            transform.rotation);//生成時の向き
        CancelInvoke();// InvokeRepeatingを止める
    }
}
