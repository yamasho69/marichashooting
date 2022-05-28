using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class ObjectPoolCtrl : MonoBehaviour
{
    public GameObject pooledObject;
    public List<GameObject> listOfPooledObjects = new List<GameObject>();
    void Start()
    {
        for(int i = 0; i < 20; i++) {
            GameObject obj = Instantiate(pooledObject,this.transform);
            obj.SetActive(false);
            listOfPooledObjects.Add(obj);
        }
        
    }

    void Update()
    {
        
    }

    public GameObject GetPooledObject() {//�߂�l��GameObject�^
        for(int i = 0; i < listOfPooledObjects.Count; i++) {
            if (listOfPooledObjects[i].activeInHierarchy == false) {//���X�g���̂��Ԗڂ̃f�[�^��false�Ȃ��
                return listOfPooledObjects[i];//���X�g��i�Ԗڂ�Ԃ�
            }
        }
        return null;//bullet���S��active�Ȃ��null��Ԃ��B
    }
}
