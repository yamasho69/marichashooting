using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8Move : MonoBehaviour {
    private float xangle;
    private float yangle;
    private Vector3 pos;
    public float x;
    public float y;
    public float speed;
    private float move;
    public float downMoveSpeed;

    private void Start() {
        pos = transform.position;
    }

    void Update() {
        // �ړ����x�ɑ���
        xangle += Time.deltaTime * speed;
        yangle += Time.deltaTime * speed * 2;

        move = move-(downMoveSpeed / 10000);//downmovespeed���A8���̎����������Ă���

        //X��Y�̒l��Sin��Cos��Tan�ɕς���Ɠ������ς��
        transform.position = new Vector3(
            // X���̕�
            pos.x + Mathf.Sin(xangle) * x,
            // Y��
            pos.y + move + Mathf.Sin(180+yangle) * y,
            // Z���̕�
            0) ;
    }
}