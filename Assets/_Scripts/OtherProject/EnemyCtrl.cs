using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class EnemyCtrl : MonoBehaviour
{
    public GameObject explosion;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("PlayerBullet")) {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
}
