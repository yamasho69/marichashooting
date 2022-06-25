using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    public GameObject title1;//�^�C�g��
    public CanvasGroup title2;//���Ȃ�B�A���t�@�l�������Ă���̂̓L�����o�X�O���[�v
    public AudioClip titleCall1;//�^�C�g���R�[��1
    public AudioClip titleCall2;//�^�C�g���R�[��2
    //public AudioClip bGM;
    public GameObject musicName;
    public GameObject buttons;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("TitleStart");
    }
    
    IEnumerator TitleStart(){
        title1.transform.DOScale(
    new Vector3(1.2f, 1.2f, 1.2f), // �X�P�[���l
    1.1f                    // ���o����
    );
        yield return new WaitForSeconds(1.16f);
        audioSource.PlayOneShot(titleCall1);
        title1.transform.DOScale(
    new Vector3(1, 1, 1), // �X�P�[���l
    0.05f                    // ���o����
    );
        yield return new WaitForSeconds(1.4f);
        title2.DOFade(
            1f,     // �t�F�[�h��̃A���t�@�l
            1f      // ���o����
        );
        audioSource.PlayOneShot(titleCall2);
        //1�t���[����~
        yield return new WaitForSeconds(3.1f);
        audioSource.Play();
        buttons.SetActive(true);
        musicName.SetActive(true);
        yield return null;
    }
}
