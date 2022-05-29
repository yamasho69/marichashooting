using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour {
    private Rigidbody2D rb;
    private Vector3 pos;
    private int timeCount;
    public float speed;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * speed;//�e�L�X�g����ύX
    }

    void Update() {
        pos = transform.position;
        timeCount += 1;//�e�L�X�g����ύX�A�G�̃|�W�V�����ł͂Ȃ��A�X�|�[������̎��Ԍo�߂ŕ����]������������

        if (timeCount > 180) {
            // �������񑬓x���O�ɂ���B
            rb.velocity = Vector3.zero;

            // �ٕ����ɗ͂�������Bx��y�ɐ��l������ƕ����]��
            rb.AddForce(new Vector3(135, 135, 0) * Time.deltaTime * -30);
        }
        if (timeCount > 200) {//���x�����ɖ߂��B�������ɐi�ށB
            rb.velocity = -transform.up * speed;
        }
    }
}