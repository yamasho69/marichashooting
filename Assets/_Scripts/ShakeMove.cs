using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeMove : MonoBehaviour {

    public float shakeWidth;//�h��镝 �e�L�X�g�ł�5.0f
    public int shakeSpan;//�h���񐔁H�@�e�L�X�g�ł�2�@�傫���ق�������������
    private Rigidbody2D rb;
    public float speed;

    public void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Time.timeScale == 1) {
            rb.velocity = -transform.up * speed;
            // �O�p�֐��̊��p�iSin�֐��j
            transform.Translate(shakeWidth * Time.deltaTime * Mathf.Sin(Time.time * shakeSpan), -Time.deltaTime * Mathf.Sin(Time.time), 0);
        }
    }
}
