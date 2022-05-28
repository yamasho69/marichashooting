using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1UPItem : Item // �uMonoBehaviour�v���uItem�v�ɕύX����i����ŁuItem�N���X�����p�v���邱�Ƃ��ł��܂��B�j
{
    private PlayerHealth ph;
    private int reward = 1;

    void Start() {
        ph = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Missile") {
            // �i�d�v�|�C���g�jItem�N���X��ItemBase���\�b�h���Ăяo���B
            base.ItemBase(other.gameObject);

            if (ph != null) {
                // �����Őݒ肵�����������@���񕜂���B
                ph.Player1UP(reward);
            }
        }
    }
}