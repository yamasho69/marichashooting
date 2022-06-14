using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGo : MonoBehaviour {
    public float startSpeed_Min = 60;
    public float startSpeed_Max = 300;
    public float nextSpeed;

    private Rigidbody2D rb;
    private GameObject target;

    private float timeCount = 0;
    public float stopTime = 3; // 弾が生成後、何秒したら停止するか？

    private float stopTimeCount = 0;
    public float nextStartTime = 2; // 弾が停止後、何秒したら動き出すか？

    private bool stopKey = false;

    void Start() {
        rb = GetComponent<Rigidbody2D>();

        // 初速はランダムにする。

        rb.velocity = -transform.up * startSpeed_Max;//テキストから変更
        //rb.AddForce(-transform.forward * Random.Range(startSpeed_Min, startSpeed_Max));

        target = GameObject.Find("Player");
    }

    void Update() {
        timeCount += Time.deltaTime;

        if (timeCount >= stopTime && !stopKey) {
            stopTimeCount += Time.deltaTime;
            rb.velocity = Vector3.zero; // 弾の速度を０にする＝弾を停止させる。

            // 弾の色を変える
           // GetComponent<SpriteRenderer>().material.color = Color.white;

            if (stopTimeCount >= nextStartTime) {
                if (target != null) {
                    // プレーヤーの方向に向きを変える。
                    //this.gameObject.transform.LookAt(target.transform.position);

                    //https://soft-rime.com/post-1584/
                    // 対象物へのベクトルを算出
                    Vector3 diff = target.transform.position - transform.position;
                    // 対象物へ回転する
                    transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
                }

                rb.velocity = transform.up * nextSpeed;//テキストから変更
                //rb.AddForce(transform.forward * nextSpeed * nextSpeed);
                stopKey = true;
            }
        }
    }
}