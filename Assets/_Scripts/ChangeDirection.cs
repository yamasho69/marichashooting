using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour {
    private Rigidbody2D rb;
    private Vector3 pos;
    private int timeCount;
    public float speed;
    [Header("一度停まるタイム。デフォルト180")]public int stopTime;
    [Header("方向転換するときにx方向にかける力。デフォルト135")]public int x;
    [Header("方向転換するときにy方向にかける力。デフォルト135")]public int y;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * speed;//テキストから変更
    }

    void Update() {
        pos = transform.position;
        timeCount += 1;//テキストから変更、敵のポジションではなく、スポーンからの時間経過で方向転換が発生する

        if (timeCount > stopTime) {
            // いったん速度を０にする。
            rb.velocity = Vector3.zero;

            // 異方向に力を加える。xとyに数値を入れると方向転換
            rb.AddForce(new Vector3(x, y, 0) * Time.deltaTime * -30);
        }
        if (timeCount > stopTime + 25) {//速度を元に戻す。下方向に進む。
            rb.velocity = -transform.up * speed;
        }
    }
}