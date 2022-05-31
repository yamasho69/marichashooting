using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class BackGround : MonoBehaviour {
    public float scrollSpeed;

    private void Update() {
        Vector2 offset = new Vector2(0, Mathf.Repeat(Time.time * scrollSpeed, 1f));
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex",offset);
    }
}
