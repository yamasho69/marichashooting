using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class Explosion : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip boomSE;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Destroy(gameObject,0.5f);//0.5•bŒã‚ÉŽ©•ª‚ð”j‰ó
        audioSource.PlayOneShot(boomSE);
    }

    void Update()
    {
        
    }
}
