using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BackGround : MonoBehaviour {
    //�X�N���[���X�s�[�h
    [SerializeField] float speed = 1;
    [SerializeField] float limitPosition;
    [SerializeField] float loopPosition;
    public bool yokoScroll = false;//�`�F�b�N�������Ă��牡�X�N���[��

    private void Start() {
        Application.targetFrameRate = 60;
    }

    void Update() {
        if (!yokoScroll) {
            //�������ɃX�N���[��
            transform.position -= new Vector3(0, Time.deltaTime * speed);

            //Y��-11�܂ŗ���΁AyPosition�܂ňړ�����
            if (transform.position.y <= limitPosition) {
                transform.position = new Vector2(0, loopPosition);
            }
        } else {
            //�������ɃX�N���[��
            transform.position -= new Vector3(Time.deltaTime * speed,0);

            //X��-11�܂ŗ���΁AxPosition�܂ňړ�����
            if (transform.position.x <= limitPosition) {
                transform.position = new Vector2(loopPosition,transform.position.y);
            }
        }
    }
}
