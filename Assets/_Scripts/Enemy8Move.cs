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
        // ˆÚ“®‘¬“x‚É‘Š“–
        xangle += Time.deltaTime * speed;
        yangle += Time.deltaTime * speed * 2;

        move = move-(downMoveSpeed / 10000);//downmovespeed•ªA8‚Ìš‚ª‰º‚ª‚Á‚Ä‚­‚é

        //X‚ÆY‚Ì’l‚âSin‚ğCos‚âTan‚É•Ï‚¦‚é‚Æ“®‚«‚ª•Ï‚í‚é
        transform.position = new Vector3(
            // X²‚Ì•
            pos.x + Mathf.Sin(xangle) * x,
            // Y²
            pos.y + move + Mathf.Sin(180+yangle) * y,
            // Z²‚Ì•
            0) ;
    }
}