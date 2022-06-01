using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BackGround : MonoBehaviour {
    //�X�N���[���X�s�[�h
    [SerializeField] float speed = 1;
    [SerializeField] float limitPosition;
    [SerializeField] float loopPosition;

    void Update() {
        //�������ɃX�N���[��
        transform.position -= new Vector3(0, Time.deltaTime * speed);

        //Y��-11�܂ŗ���΁AyPosition�܂ňړ�����
        if (transform.position.y <= limitPosition) {
            transform.position = new Vector2(0, loopPosition);
        }
    }
}
