using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //public GameObject effectPrefab;
    [Header("アイテムvoice")]public AudioClip[] clips;
    private AudioClip sound;

    // （ポイント）先頭に「public」をつけること。
    public void ItemBase(GameObject target)
    {
        //GameObject effect = Instantiate(effectPrefab, target.transform.position, Quaternion.identity);
        //Destroy(effect, 1.0f);
        sound = GetRandom(clips);
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
        //（ポイント）
        // アイテムは破壊ではなく非アクティブ状態にする。
        // パワーアップアイテムとの関係から。
        this.gameObject.SetActive(false);

        // ミサイルを破壊する。
        //Destroy(target.gameObject);
    }
    internal static T GetRandom<T>(params T[] Params) {
        return Params[UnityEngine.Random.Range(0, Params.Length)];
    }
}