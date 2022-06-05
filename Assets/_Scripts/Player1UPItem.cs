using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1UPItem : Item // 「MonoBehaviour」を「Item」に変更する（これで「Itemクラスを承継」することができます。）
{
    private PlayerHealth ph;
    private int reward = 1;

    void Start() {
        ph = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    //アクティブになるときx座標はランダムにする。
    private void OnEnable() {
        //https://www.sejuku.net/blog/51251
        Transform myTransform = this.transform;
        // 座標を取得
        Vector3 pos = myTransform.position;
        pos.x = Random.Range(-2.0f, 2.0f);
        pos.y =6f;
        myTransform.position = pos;  // 座標を設定
    }

    //取り損ねた時に消える。
    private void Update() {
        if(transform.position.y < -7) {
            this.gameObject.SetActive(false);
        }
    }

    //PlayerにRigidbody2Dを付けないと振れたことにならない
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            // （重要ポイント）ItemクラスのItemBaseメソッドを呼び出す。
            base.ItemBase(other.gameObject);

            if (ph != null) {
                // 自分で設定した分だけ自機が回復する。
                ph.Player1UP(reward);
            }
        }
    }
}