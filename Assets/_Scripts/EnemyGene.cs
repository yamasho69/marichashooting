using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGene : MonoBehaviour {
    public GameObject enemyPrefab;
    public float speed;
    [Header("�G�𐶂ݏo����")]public int spawnCount;
    [Header("��x�ɓG�𐶂ݏo����")]public int oneSpawn;
    [Header("���ݏo���Ԋu")]public float spawnSpan;
    [Header("��C��C�̊Ԋu")]public float spawnInterval;

    private void Start() {
        StartCoroutine(GeneEnemy());
    }

    // �i�|�C���g�j�R���[�`��
    IEnumerator GeneEnemy() {
        // ����J��Ԃ����͎��R�ɐݒ�
        for (int j = 0; j < spawnCount; j++) {
            for (int i = 0; i < oneSpawn; i++) {
                GameObject enemey = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(0, 0, 0));//��]�����Ȃ��悤�ɕύX
                Rigidbody2D enemyRb = enemey.GetComponent<Rigidbody2D>();//2D�ɕύX
                enemyRb.velocity = transform.up * speed;//�e�L�X�g����ύX
                Destroy(enemey, 5f);

                // 0.2�b���Ƃɓ�����J��Ԃ��i���R�ɕύX�\�j
                yield return new WaitForSeconds(spawnInterval);
            }

            // 3�b���Ƃɓ�����J��Ԃ��i���R�ɕύX�\�j
            yield return new WaitForSeconds(spawnSpan);
        }
    }
}