using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureItem : Item  // �uMonoBehaviour�v���uItem�v�ɕύX����i����ŁuItem�N���X�����p�v���邱�Ƃ��ł��܂��B�j
{
    private PlayerHealth ph;
    private int reward = 3;

    private void Start() {
        // �uPlayer�v�ɂ��Ă���uPlayerHealth�v�X�N���v�g�ɃA�N�Z�X����B
        ph = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other) {
        // �v���[���[�̃~�T�C���Ŕj�󂷂��HP���񕜂���
        if (other.gameObject.tag == "Missile") {
            // �i�d�v�|�C���g�jItem�N���X��ItemBase���\�b�h���Ăяo���B
            // �G�t�F�N�g�A���ʉ����͂���Ŕ������܂��B
            base.ItemBase(other.gameObject);

            if (ph != null) {
                // �v���[���[��HP���������w�肵���ʂ����񕜂�����
                ph.AddHP(reward);
            }
        }
    }
}