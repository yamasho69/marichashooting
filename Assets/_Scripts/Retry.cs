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
        SceneManager.LoadScene("Stage01");
    }
}
