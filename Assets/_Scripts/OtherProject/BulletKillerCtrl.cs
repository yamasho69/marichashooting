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
        //if (collision.tag == "PlayerBullet") {//CompareTag‚Ì‚Ù‚¤‚ª‘‚¢‚æ‚¤‚¾‚ªg‚¢•û‚ª‚í‚©‚ç‚È‚¢
        if (collision.CompareTag("Missile")) {//CompareTag‚Ì‚Ù‚¤‚ª‘‚¢‚æ‚¤‚¾‚ªg‚¢•û‚ª‚í‚©‚ç‚È‚¢
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
