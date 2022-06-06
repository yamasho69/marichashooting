using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour {
    private Rigidbody2D rb;
    private Vector3 pos;
    private int timeCount;
    public float speed;
    [Header("��x��܂�^�C���B�f�t�H���g180")]public int stopTime;
    [Header("�����]������Ƃ���x�����ɂ�����́B�f�t�H���g135")]public int x;
    [Header("�����]������Ƃ���y�����ɂ�����́B�f�t�H���g135")]public int y;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * speed;//�e�L�X�g����ύX
    }

    void Update() {
        pos = transform.position;
        timeCount += 1;//�e�L�X�g����ύX�A�G�̃|�W�V�����ł͂Ȃ��A�X�|�[������̎��Ԍo�߂ŕ����]������������

        if (timeCount > stopTime) {
            // �������񑬓x���O�ɂ���B
            rb.velocity = Vector3.zero;

            // �ٕ����ɗ͂�������Bx��y�ɐ��l������ƕ����]��
            rb.AddForce(new Vector3(x, y, 0) * Time.deltaTime * -30);
        }
        if (timeCount > stopTime + 25) {//���x�����ɖ߂��B�������ɐi�ށB
            rb.velocity = -transform.up * speed;
        }
    }
}