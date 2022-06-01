using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BackGround : MonoBehaviour {
    //スクロールスピード
    [SerializeField] float speed = 1;
    [SerializeField] float limitPosition;
    [SerializeField] float loopPosition;

    void Update() {
        //下方向にスクロール
        transform.position -= new Vector3(0, Time.deltaTime * speed);

        //Yが-11まで来れば、yPositionまで移動する
        if (transform.position.y <= limitPosition) {
            transform.position = new Vector2(0, loopPosition);
        }
    }
}
