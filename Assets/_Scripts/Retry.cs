using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class Retry: MonoBehaviour {
    [Header("�^�C�g���ɖ߂�")]public bool backTitle;

    // ���i�ǉ��j
    // �擪�Ɂupublic�v�����邱�Ɓi�|�C���g�j
    public void OnRestartButtonClicked() {
        if (backTitle) {
            SceneManager.LoadScene("Title");//backTitle��on�Ȃ�Title��
            ScoreManager.nowStage = "Stage1";
        } else { SceneManager.LoadScene(ScoreManager.nowStage); }//backTitle��off�Ȃ獡�̃X�e�[�W��
        // ���ǉ�
        // �X�R�A���O�ɖ߂��B
        // ���X�N���v�g�̒��ɂ���u�ÓI�ϐ��v�̑�����@�i�|�C���g�j
        ScoreManager.score = 0;
        ScoreManager.oneUPscore = 500;
        ScoreManager.highScoreUpdate = false;//�n�C�X�R�A���X�V���Ă����ꍇ�͍X�V���Ă��Ȃ���Ԃɖ߂��B
        PlayerHealth.zanki = 3;
        Time.timeScale = 1;//�|�[�Y����߂����ꍇ�͎��Ԃ𓮂����B
    }
}
