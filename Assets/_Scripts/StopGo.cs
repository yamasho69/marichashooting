using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGo : MonoBehaviour {
    public float startSpeed_Min = 60;
    public float startSpeed_Max = 300;
    public float nextSpeed;

    private Rigidbody2D rb;
    private GameObject target;

    private float timeCount = 0;
    public float stopTime = 3; // �e��������A���b�������~���邩�H

    private float stopTimeCount = 0;
    public float nextStartTime = 2; // �e����~��A���b�����瓮���o�����H

    private bool stopKey = false;

    void Start() {
        rb = GetComponent<Rigidbody2D>();

        // �����̓����_���ɂ���B

        rb.velocity = -transform.up * startSpeed_Max;//�e�L�X�g����ύX
        //rb.AddForce(-transform.forward * Random.Range(startSpeed_Min, startSpeed_Max));

        target = GameObject.Find("Player");
    }

    void Update() {
        timeCount += Time.deltaTime;

        if (timeCount >= stopTime && !stopKey) {
            stopTimeCount += Time.deltaTime;
            rb.velocity = Vector3.zero; // �e�̑��x���O�ɂ��遁�e���~������B

            // �e�̐F��ς���
           // GetComponent<SpriteRenderer>().material.color = Color.white;

            if (stopTimeCount >= nextStartTime) {
                if (target != null) {
                    // �v���[���[�̕����Ɍ�����ς���B
                    //this.gameObject.transform.LookAt(target.transform.position);

                    //https://soft-rime.com/post-1584/
                    // �Ώە��ւ̃x�N�g�����Z�o
                    Vector3 diff = target.transform.position - transform.position;
                    // �Ώە��։�]����
                    transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
                }

                rb.velocity = transform.up * nextSpeed;//�e�L�X�g����ύX
                //rb.AddForce(transform.forward * nextSpeed * nextSpeed);
                stopKey = true;
            }
        }
    }
}