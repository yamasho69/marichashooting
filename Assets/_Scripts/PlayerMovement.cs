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
    void Update() {
        // ★改良（下記の２行をコメントアウトする）
        float moveH = Input.GetAxis("Horizontal") * moveSpeed;
        float moveV = Input.GetAxis("Vertical") * moveSpeed;

        // ★改良（下記の２行を追加する）
        //float moveH = Input.GetAxis("Mouse X") * moveSpeed;
        //float moveV = Input.GetAxis("Mouse Y") * moveSpeed;

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
