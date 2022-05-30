using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpMove : MonoBehaviour {
    public float leftLimit;
    public float rightLimit;
    public float topLimit;
    public float bottomLimit;

    void Start() {
        StartCoroutine(Warp());
    }

    private IEnumerator Warp() {
        while (true) {
            yield return new WaitForSeconds(3.0f);

            // ランダムに移動させる範囲は自由に変更可能
            float posX = Random.Range(leftLimit, rightLimit);
            float posY = Random.Range(bottomLimit, topLimit);

            transform.position = new Vector3(posX,posY,0);
        }
    }
}