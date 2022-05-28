using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    // ���ǉ�
    private int score = 0;
    private Text scoreLabel;

    void Start() {
        // ���ǉ�
        // �uText�v�R���|�[�l���g�ɃA�N�Z�X���Ď擾����i�|�C���g�j
        scoreLabel = GetComponent<Text>();
        scoreLabel.text = "SCORE:" + score;
    }

    // ���ǉ�
    // �X�R�A�����Z���郁�\�b�h�i���߃u���b�N�j
    // �upublic�v�����ĊO�����炱�̃��\�b�h�ɃA�N�Z�X�ł���悤�ɂ���i�d�v�|�C���g�j
    public void AddScore(int amount) {
        // �uamount�v�ɓ����Ă��鐔�l�������Z���Ă����B
        score += amount;
        scoreLabel.text = "SCORE:" + score;
    }
}
