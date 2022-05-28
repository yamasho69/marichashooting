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

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Missile") {
            // （重要ポイント）ItemクラスのItemBaseメソッドを呼び出す。
            base.ItemBase(other.gameObject);

            if (ph != null) {
                // 自分で設定した分だけ自機が回復する。
                ph.Player1UP(reward);
            }
        }
    }
}