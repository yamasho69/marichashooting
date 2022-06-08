using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class PlayerHealth : MonoBehaviour {
    public GameObject effectPrefab;
    private AudioClip destroySound;
    public static int zanki = 3;

    // ���ǉ��i�V���b�g�p���[�̑S�񕜁j
    public FireMissile fireMissile;

    // ���ǉ��i���G�j
    public bool isMuteki = false;
    public float mutekiTime;

    float alpha_Sin;
    private Color _color;

    [Header("����voice")][SerializeField] AudioClip[] clips;


    private void Update() {
        alpha_Sin = Mathf.Sin(Time.time*30) / 2 + 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // ���ǉ��i���G�j
        // �������̒��Ɂu&& isMuteki == false�v��ǉ�
        if (other.gameObject.CompareTag("EnemyMissile") && isMuteki == false) {
            //Destroy(other.gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            destroySound = GetRandom(clips);
            AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
            Destroy(effect, 1.0f);
            this.gameObject.SetActive(false);
            zanki--;
            Debug.Log(zanki);

            // �������i�ǉ��j
            // �j�󂳂ꂽ�񐔂ɂ���ďꍇ�������s���܂��B
            if (zanki >= 0) // �����̏����͎����̃Q�[���ɍ��킹�܂��傤�I
            {
                // ���g���C
                Invoke("Retry", 1.0f);
            } else {
                // �Q�[���I�[�o�[
                Invoke("GameOver", 1.0f);
            }
        }
    }
    void GameOver() {
        SceneManager.LoadScene("GameOver");
    }
    // �����i�ǉ��j
    // �Q�[�����g���C�Ɋւ��閽�߃u���b�N
    void Retry() {
        this.gameObject.SetActive(true);
        // ���ǉ��i���G�j
        // ���b�Ԗ��G��Ԃɂ��邩�͎��R�I
        isMuteki = true;
        StartCoroutine("ColorCoroutine");
        Invoke("MutekiOff", mutekiTime);

        // ���ǉ��i�V���b�g�p���[�̑S�񕜁j
        fireMissile.shotPower = fireMissile.maxPower;
    }

    // ���ǉ��i���G�j
    void MutekiOff() {
        isMuteki = false;
        StopCoroutine("ColorCoroutine");
        Color _color = GetComponent<Renderer>().material.color;

        _color.a = 1;
        GetComponent<Renderer>().material.color = _color;
    }

    // ���ǉ��i���@1UP�A�C�e���j
    // �upublic�v��t���邱�Ɓi�|�C���g�j
    public void Player1UP(int amount) {
        if (zanki < 99) {
            zanki++;
        }
    }

    IEnumerator ColorCoroutine() {
        while (true) {
            yield return new WaitForEndOfFrame();
            Color _color = GetComponent<Renderer>().material.color;
            _color.a = alpha_Sin;
            GetComponent<Renderer>().material.color = _color;
        }
    }

    internal static T GetRandom<T>(params T[] Params) {
        return Params[UnityEngine.Random.Range(0, Params.Length)];
    }
}
