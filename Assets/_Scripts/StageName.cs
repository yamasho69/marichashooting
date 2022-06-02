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
    [Header("�������傫���Ƒ���������")] public float vanishTime;
    [Header("�X�e�[�W���ȊO�Ɏg���Ƃ��͊O��")] public bool stageNameUse;
    [Header("���b�ォ�甖���Ȃ邩")] public float clearStartTime;
    private bool startClear = false;

    void Start() {
        // ���ǉ�
        // �uText�v�R���|�[�l���g�ɃA�N�Z�X���Ď擾����B
        stageNameText = this.gameObject.GetComponent<Text>();

        if (stageNameUse) {
            // ���ǉ�
            // ���݂̃V�[���̖��O���擾����text�v���p�e�B�ɃZ�b�g����i�|�C���g�j
            stageNameText.text = SceneManager.GetActiveScene().name;
        }

        Invoke("StartClear", clearStartTime);
    }

    void Update() {
        if (startClear) {
            // ���ǉ�
            stageNameText.color = Color.Lerp(stageNameText.color, new Color(1, 1, 1, 0), vanishTime * Time.deltaTime);
        }
    } 

    void StartClear() {
        startClear = true;
    }
}
