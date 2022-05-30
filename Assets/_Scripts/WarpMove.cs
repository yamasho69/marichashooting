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

            // �����_���Ɉړ�������͈͎͂��R�ɕύX�\
            float posX = Random.Range(leftLimit, rightLimit);
            float posY = Random.Range(bottomLimit, topLimit);

            transform.position = new Vector3(posX,posY,0);
        }
    }
}