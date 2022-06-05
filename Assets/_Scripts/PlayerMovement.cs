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
    public FixedJoystick joystick;
    private float moveH = 0;
    private float moveV = 0;
    private bool joystickOn;
    void Update() {

        float joyH = joystick.Horizontal;
        float joyV = joystick.Vertical;
        if(joyH != 0 || joyV != 0) {
            joystickOn = true;
        }else {
            joystickOn = false;
        }

        // �����ǁi���L�̂Q�s���R�����g�A�E�g����j
        if (!joystickOn) {
            moveH = Input.GetAxis("Horizontal") * moveSpeed;
        }else{
            moveH = joyH * moveSpeed;
        }

        if (!joystickOn) {
            moveV = Input.GetAxis("Vertical") * moveSpeed;
        } else {
            moveV = joyV * moveSpeed;
        }

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
