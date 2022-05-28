using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class BulletCtrl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 8f;

    public AudioSource sfxSource;
    [Header("���Ȃ�SE")] public AudioClip[] onaraSE;
    void Start()
    {

    }

    private void OnEnable() {//�A�N�e�B�u�����ꂽ���Ɏ��s�����
        RandomizeSfx(onaraSE);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, bulletSpeed);
    }

    public void RandomizeSfx(params AudioClip[] clips) {
        var randomIndex = UnityEngine.Random.Range(0, clips.Length);
        sfxSource.PlayOneShot(clips[randomIndex]);
    }
}
