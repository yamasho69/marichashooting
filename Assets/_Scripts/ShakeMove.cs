using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeMove : MonoBehaviour {

    public float shakeWidth;//揺れる幅 テキストでは5.0f
    public int shakeSpan;//揺れる回数？　テキストでは2　大きいほうが激しく動く
    private Rigidbody2D rb;
    public float speed;

    public void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Time.timeScale == 1) {
            rb.velocity = -transform.up * speed;
            // 三角関数の活用（Sin関数）
            transform.Translate(shakeWidth * Time.deltaTime * Mathf.Sin(Time.time * shakeSpan), -Time.deltaTime * Mathf.Sin(Time.time), 0);
        }
    }
}
