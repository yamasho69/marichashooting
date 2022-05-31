using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene_StopGo : MonoBehaviour {
    public GameObject stopGoPrefab;
    private int timeCount;

    void Update() {
        timeCount += 1;

        if (timeCount % 500 == 0) {
            GameObject stopGo = Instantiate(stopGoPrefab, transform.position, Quaternion.identity);
            Destroy(stopGo,5f);
        }
    }
}