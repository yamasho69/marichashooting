using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class Retry: MonoBehaviour {
    // ���i�ǉ��j
    // �擪�Ɂupublic�v�����邱�Ɓi�|�C���g�j
    public void OnRestartButtonClicked() {
        SceneManager.LoadScene("Stage1");
        // ���ǉ�
        // �X�R�A���O�ɖ߂��B
        // ���X�N���v�g�̒��ɂ���u�ÓI�ϐ��v�̑�����@�i�|�C���g�j
        ScoreManager.score = 0;
        ScoreManager.oneUPscore = 500;
        PlayerHealth.zanki = 3;
    }
}
