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
    //public AudioClip damageSound;
    private AudioClip destroySound;
    // �����ǁi�ő�HP�j
    // �upublic�v���uprivate�v�ɕύX
    // maxHP��ݒ�iHP�̍ő�l�͎��R�ɐݒ�j
    private int playerHP;
    private int maxHP = 1;

    
    // ���ǉ�
    //public Slider hpSlider;
    // ���i�ǉ��j
    // �z��̒�`�i�u�����̃f�[�^�v�����邱�Ƃ̂ł���u�d�؂�v�t���̔������j
    public GameObject[] playerIcons;

    // ���i�ǉ��j
    // �v���[���[���j�󂳂ꂽ�񐔂̃f�[�^�����锠
    // ���C��
    public static int destroyCount = 0;

    [Header("���̉񐔔j�󂳂ꂽ��Q�[���I�[�o�[")]public int gameOverDestroyCount;

    // ���ǉ��i���G�j
    public bool isMuteki = false;

    float alpha_Sin;
    private Color _color;

    [Header("����voice")][SerializeField] AudioClip[] clips;
    //[SerializeField] AudioSource source;

    // ���ǉ�
    private void Start() {
        // ���ǉ�
        // ���̂P�s��ǉ����Ȃ��ƁA�c�@���f�[�^�Ǝc�@���̕\���i�A�C�R�����j������Ă��܂��B
        UpdatePlayerIcons();

        // �����ǁi�ő�HP�j
        playerHP = maxHP;
        // �X���C�_�[�̍ő�l�̐ݒ�
        //hpSlider.maxValue = playerHP;

        // �X���C�_�[�̌��ݒl�̐ݒ�
        //hpSlider.value = playerHP;
    }

    private void Update() {
        alpha_Sin = Mathf.Sin(Time.time*30) / 2 + 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // ���ǉ��i���G�j
        // �������̒��Ɂu&& isMuteki == false�v��ǉ�
        if (other.gameObject.CompareTag("EnemyMissile") && isMuteki == false) {
            playerHP -= 1;
            //AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position);

            Destroy(other.gameObject);

            // ���ǉ�
            // �X���C�_�[�̌��ݒl
            //hpSlider.value = playerHP;

            if (playerHP == 0) {
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                destroySound = GetRandom(clips);
                AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
                Destroy(effect, 1.0f);
                this.gameObject.SetActive(false);
                // ���i�ǉ��j
                // HP���O�ɂȂ�����j�󂳂ꂽ�񐔂��P����������B
                destroyCount += 1;

                // ���i�ǉ��j
                // ���߃u���b�N�i���\�b�h�j���Ăяo���B
                UpdatePlayerIcons();

                // �������i�ǉ��j
                // �j�󂳂ꂽ�񐔂ɂ���ďꍇ�������s���܂��B
                if (destroyCount < gameOverDestroyCount) // �����̏����͎����̃Q�[���ɍ��킹�܂��傤�I
                {
                    // ���g���C
                    Invoke("Retry", 1.0f);
                } else {
                    // �Q�[���I�[�o�[
                    Invoke("GameOver", 1.0f);

                    // destroyCount�����Z�b�g
                    destroyCount = 0;
                }
            }
        }
    }
    void GameOver() {
        SceneManager.LoadScene("GameOver");
    }

    // ���i�ǉ��j
    // �v���[���[�̎c�@����\�����閽�߃u���b�N�i���\�b�h�j
    void UpdatePlayerIcons() {
        // for���i�J��Ԃ����j�E�E�E�܂��͊�{�`���o���܂��傤�I
        for (int i = 0; i < playerIcons.Length; i++) {
            if (destroyCount <= i) {
                playerIcons[i].SetActive(true);
            } else {
                playerIcons[i].SetActive(false);
            }
        }
    }

    // �����i�ǉ��j
    // �Q�[�����g���C�Ɋւ��閽�߃u���b�N
    void Retry() {
        this.gameObject.SetActive(true);
        // �����ǁi�ő�HP�j
        playerHP = maxHP;
        //hpSlider.value = playerHP;
        // ���ǉ��i���G�j
        // ���b�Ԗ��G��Ԃɂ��邩�͎��R�I
        isMuteki = true;
        StartCoroutine("ColorCoroutine");
        Invoke("MutekiOff", 1.5f);

    }

    // ���ǉ��i���G�j
    void MutekiOff() {
        isMuteki = false;
        StopCoroutine("ColorCoroutine");
        Color _color = GetComponent<Renderer>().material.color;

        _color.a = 1;
        GetComponent<Renderer>().material.color = _color;
    }

    // ���ǉ��iHP�񕜃A�C�e���j
    // �upublic�v��t���邱�Ɓi�|�C���g�j
    public void AddHP(int amount) {
        // �uamount�v������HP���񕜂�����
        playerHP += amount;

        // �ő�HP�ȏ�ɂ͉񕜂��Ȃ��悤�ɂ���B
        if (playerHP > maxHP) {
            playerHP = maxHP;
        }

        // HP�X���C�_�[
        //hpSlider.value = playerHP;
    }
    // ���ǉ��i���@1UP�A�C�e���j
    // �upublic�v��t���邱�Ɓi�|�C���g�j
    public void Player1UP(int amount) {
        // amount���������@�̎c�@���񕜂�����B
        // �i�l�����j�j�󂳂ꂽ�񐔁i�udestroyCount�v�j��amount����������������B
        destroyCount -= amount;

        // �ő�c�@���𒴂��Ȃ��悤�ɂ���i�j�󂳂ꂽ�񐔂��O�����ɂȂ�Ȃ��悤�ɂ���j
        if (destroyCount < 0) {
            destroyCount = 0;
        }

        // �c�@����\������A�C�R��
        UpdatePlayerIcons();
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
