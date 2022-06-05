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
    // ★追加
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

        // ★改良（下記の２行をコメントアウトする）
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
        // ★追加
        MoveClamp();
    }

    // ★追加
    void MoveClamp() {
        pos = transform.position;

        //Mathf.Clamp(a,b,c) aの値をb以上c以下に制限する。
        pos.x = Mathf.Clamp(pos.x,left, right);
        pos.y = Mathf.Clamp(pos.y,down,up);

        transform.position = pos;
    }
}
