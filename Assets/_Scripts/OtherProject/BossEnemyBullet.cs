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

    //�e�̎ˏo�p�x�𒲐�����
    public void Setting(float angle,float speed)
    {
        //2PI��360�x
        //PI��180�x
        //PI/2��90�x
        //�G�̉E����0�x
        //�����v���Ɋp�x���������B

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
