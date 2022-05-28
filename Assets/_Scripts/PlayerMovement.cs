using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    // ���ǉ�
    private Vector3 pos;
    [SerializeField] float left;
    [SerializeField] float right;
    [SerializeField] float up;
    [SerializeField] float down;
    void Update() {
        // �����ǁi���L�̂Q�s���R�����g�A�E�g����j
        float moveH = Input.GetAxis("Horizontal") * moveSpeed;
        float moveV = Input.GetAxis("Vertical") * moveSpeed;

        // �����ǁi���L�̂Q�s��ǉ�����j
        //float moveH = Input.GetAxis("Mouse X") * moveSpeed;
        //float moveV = Input.GetAxis("Mouse Y") * moveSpeed;

        transform.Translate(moveH,moveV,0);
        // ���ǉ�
        MoveClamp();
    }

    // ���ǉ�
    void MoveClamp() {
        pos = transform.position;


        //Mathf.Clamp(a,b,c) a�̒l��b�ȏ�c�ȉ��ɐ�������B
        pos.x = Mathf.Clamp(pos.x,left, right);
        pos.y = Mathf.Clamp(pos.y,down,up);

        transform.position = pos;
    }
}
