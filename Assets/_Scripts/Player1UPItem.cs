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

    //�A�N�e�B�u�ɂȂ�Ƃ�x���W�̓����_���ɂ���B
    private void OnEnable() {
        //https://www.sejuku.net/blog/51251
        Transform myTransform = this.transform;
        // ���W���擾
        Vector3 pos = myTransform.position;
        pos.x = Random.Range(-2.0f, 2.0f);
        pos.y =6f;
        myTransform.position = pos;  // ���W��ݒ�
    }

    //��葹�˂����ɏ�����B
    private void Update() {
        if(transform.position.y < -7) {
            this.gameObject.SetActive(false);
        }
    }

    //Player��Rigidbody2D��t���Ȃ��ƐU�ꂽ���ƂɂȂ�Ȃ�
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            // �i�d�v�|�C���g�jItem�N���X��ItemBase���\�b�h���Ăяo���B
            base.ItemBase(other.gameObject);

            if (ph != null) {
                // �����Őݒ肵�����������@���񕜂���B
                ph.Player1UP(reward);
            }
        }
    }
}