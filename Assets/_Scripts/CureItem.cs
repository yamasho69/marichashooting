using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureItem : Item  // 「MonoBehaviour」を「Item」に変更する（これで「Itemクラスを承継」することができます。）
{
    private PlayerHealth ph;
    private int reward = 3;

    private void Start() {
        // 「Player」についている「PlayerHealth」スクリプトにアクセスする。
        ph = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other) {
        // プレーヤーのミサイルで破壊するとHPが回復する
        if (other.gameObject.tag == "Missile") {
            // （重要ポイント）ItemクラスのItemBaseメソッドを呼び出す。
            // エフェクト、効果音等はこれで発生します。
            base.ItemBase(other.gameObject);

            if (ph != null) {
                // プレーヤーのHPを自分が指定した量だけ回復させる
                ph.AddHP(reward);
            }
        }
    }
}