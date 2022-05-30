using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class StageName : MonoBehaviour {
    // ���ǉ�
    private Text stageNameText;

    void Start() {
        // ���ǉ�
        // �uText�v�R���|�[�l���g�ɃA�N�Z�X���Ď擾����B
        stageNameText = this.gameObject.GetComponent<Text>();


        // ���ǉ�
        // ���݂̃V�[���̖��O���擾����text�v���p�e�B�ɃZ�b�g����i�|�C���g�j
        stageNameText.text = SceneManager.GetActiveScene().name;
    }

    void Update() {
        // ���ǉ�
        stageNameText.color = Color.Lerp(stageNameText.color, new Color(1, 1, 1, 0), 0.5f * Time.deltaTime);
    }
}
