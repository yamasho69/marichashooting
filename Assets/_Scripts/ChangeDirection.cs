using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour {
    private Rigidbody2D rb;
    private Vector3 pos;
    private int timeCount;
    public float speed;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * speed;//テキストから変更
    }

    void Update() {
        pos = transform.position;
        timeCount += 1;//テキストから変更、敵のポジションではなく、スポーンからの時間経過で方向転換が発生する

        if (timeCount > 180) {
            // いったん速度を０にする。
            rb.velocity = Vector3.zero;

            // 異方向に力を加える。xとyに数値を入れると方向転換
            rb.AddForce(new Vector3(135, 135, 0) * Time.deltaTime * -30);
        }
        if (timeCount > 200) {//速度を元に戻す。下方向に進む。
            rb.velocity = -transform.up * speed;
        }
    }
}