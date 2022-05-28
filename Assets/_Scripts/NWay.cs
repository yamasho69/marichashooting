using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWay : MonoBehaviour {
    public GameObject enemyFireMissilePrefab;
    // 何方向（何Way）ミサイルを発射するかを決める
    public int wayNumber;

    void Start() {
        // for文（繰り返し文）を活用する（重要ポイント）
        for (int i = 0; i < wayNumber; i++) {
            // Instantiate()は、プレハブからクローンを産み出すメソッド（重要ポイント）
            // Quaternion.Euler(x, y, z)
            //教材ではy座標を変えていたが、2Dではz座標を変えるように改良。
            // 今回は「i = 0の時 → y = -30」「i = 1の時 → y = -15」「i = 2の時 → y = 0」「i = 3の時 → y = 15」「i = 4の時 → y = 15」になるようにする。
            // ★改良（箱の作成）
            GameObject enemyFireMissile = Instantiate(enemyFireMissilePrefab, transform.position, Quaternion.Euler(0, 0, 7.5f - (7.5f * wayNumber) + (15 * i)));

            // ★追加
            // SetParent()は親子関係を作るメソッド（ポイント）
            // 『このスクリプトが付いているNWayオブジェクトをenemyFireMissileクローンの親に設定する。』
            enemyFireMissile.transform.SetParent(this.gameObject.transform);
        }
    }
}
