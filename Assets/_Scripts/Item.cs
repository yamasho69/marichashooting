using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //public GameObject effectPrefab;
    public AudioClip sound;

    // �i�|�C���g�j�擪�Ɂupublic�v�����邱�ƁB
    public void ItemBase(GameObject target)
    {
        //GameObject effect = Instantiate(effectPrefab, target.transform.position, Quaternion.identity);
        //Destroy(effect, 1.0f);
        AudioSource.PlayClipAtPoint(sound, transform.position);

        //�i�|�C���g�j
        // �A�C�e���͔j��ł͂Ȃ���A�N�e�B�u��Ԃɂ���B
        // �p���[�A�b�v�A�C�e���Ƃ̊֌W����B
        this.gameObject.SetActive(false);

        // �~�T�C����j�󂷂�B
        Destroy(target.gameObject);
    }
}