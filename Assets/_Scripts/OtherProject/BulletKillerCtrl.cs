using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class BulletKillerCtrl : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //if (collision.tag == "PlayerBullet") {//CompareTagのほうが早いようだが使い方がわからない
        if (collision.CompareTag("PlayerBullet")) {//CompareTagのほうが早いようだが使い方がわからない
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
