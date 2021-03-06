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
        if (Time.timeScale == 1) {
            // 移動速度に相当
            xangle += Time.deltaTime * speed;
            yangle += Time.deltaTime * speed * 2;

            move = move - Time.deltaTime*downMoveSpeed/10;//downmovespeed分、8時の字が下がってくる

            //XとYの値やSinをCosやTanに変えると動きが変わる
            transform.position = new Vector3(
                // X軸の幅
                pos.x + Mathf.Sin(xangle) * x,
                // Y軸
                pos.y + move + Mathf.Sin(180 + yangle) * y,
                // Z軸の幅
                0);
        }
    }
}