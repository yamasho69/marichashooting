using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //public GameObject effectPrefab;
    [Header("�A�C�e��voice")]public AudioClip[] clips;
    private AudioClip sound;

    // �i�|�C���g�j�擪�Ɂupublic�v�����邱�ƁB
    public void ItemBase(GameObject target)
    {
        //GameObject effect = Instantiate(effectPrefab, target.transform.position, Quaternion.identity);
        //Destroy(effect, 1.0f);
        sound = GetRandom(clips);
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
        //�i�|�C���g�j
        // �A�C�e���͔j��ł͂Ȃ���A�N�e�B�u��Ԃɂ���B
        // �p���[�A�b�v�A�C�e���Ƃ̊֌W����B
        this.gameObject.SetActive(false);

        // �~�T�C����j�󂷂�B
        //Destroy(target.gameObject);
    }
    internal static T GetRandom<T>(params T[] Params) {
        return Params[UnityEngine.Random.Range(0, Params.Length)];
    }
}