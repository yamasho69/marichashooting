using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWay : MonoBehaviour {
    public GameObject enemyFireMissilePrefab;
    // �������i��Way�j�~�T�C���𔭎˂��邩�����߂�
    public int wayNumber;

    void Start() {
        // for���i�J��Ԃ����j�����p����i�d�v�|�C���g�j
        for (int i = 0; i < wayNumber; i++) {
            // Instantiate()�́A�v���n�u����N���[�����Y�ݏo�����\�b�h�i�d�v�|�C���g�j
            // Quaternion.Euler(x, y, z)
            //���ނł�y���W��ς��Ă������A2D�ł�z���W��ς���悤�ɉ��ǁB
            // ����́ui = 0�̎� �� y = -30�v�ui = 1�̎� �� y = -15�v�ui = 2�̎� �� y = 0�v�ui = 3�̎� �� y = 15�v�ui = 4�̎� �� y = 15�v�ɂȂ�悤�ɂ���B
            // �����ǁi���̍쐬�j
            GameObject enemyFireMissile = Instantiate(enemyFireMissilePrefab, transform.position, Quaternion.Euler(0, 0, 7.5f - (7.5f * wayNumber) + (15 * i)));

            // ���ǉ�
            // SetParent()�͐e�q�֌W����郁�\�b�h�i�|�C���g�j
            // �w���̃X�N���v�g���t���Ă���NWay�I�u�W�F�N�g��enemyFireMissile�N���[���̐e�ɐݒ肷��B�x
            enemyFireMissile.transform.SetParent(this.gameObject.transform);
        }
    }
}
