using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class BossEnemyBullet : MonoBehaviour
{
    float dx;
    float dy;

    //弾の射出角度を調整する
    public void Setting(float angle,float speed)
    {
        //2PIは360度
        //PIは180度
        //PI/2が90度
        //敵の右側が0度
        //反時計回りに角度が足される。

        dx = Mathf.Cos(angle)*speed;
        dy = Mathf.Sin(angle)*speed;
    }

    void Update()
    {
        transform.position += new Vector3(dx, dy, 0) * Time.deltaTime;

        if (transform.position.x < -7 || transform.position.x > 7 ||
            transform.position.y < -7 || transform.position.y > 7) {
            Destroy(gameObject);
        }
    }
}
