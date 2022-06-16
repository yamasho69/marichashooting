using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DG.Tweening;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    private Vector2 moveDirection;
    private Rigidbody2D rb;

    public GameObject bullet;
    public GameObject firePosition;
    private float cooldownTimer = 0;
    public float timeInterval = 0.2f;
    [SerializeField] ObjectPoolCtrl objectPoolCtrl;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = new Vector2(0.0f, 0.0f); 
    }

    void Update()
    {
        if (Time.timeScale == 1) {//これがないとタイム中に左右でショットパワーを増減できる。
            ProcessInputs();
            if (Input.GetKey(KeyCode.Space)) {
                Fire();
            }
        }
        cooldownTimer -= Time.deltaTime;
    }

    private void FixedUpdate() {
        Move();
    }

    void ProcessInputs() {
        /*float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection.x = moveX;
        moveDirection.y = moveY;

        moveDirection.Normalize();//ここイマイチわからん。*/
        float x = Input.GetAxisRaw("Horizontal");//GetAxisRawだとすぐ動き、すぐ停まる機敏な動きに変わる
        float y = Input.GetAxisRaw("Vertical");
        Vector3 nextPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * 4f;
        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x, -2.5f, 2.5f),//nextPosition.xを第二引数と第三引数以内に制限できる。
            Mathf.Clamp(nextPosition.y, -4.0f, 4.5f),
            nextPosition.z
            );
        transform.position = nextPosition;
    }

    void Move() {
        rb.velocity = moveDirection * moveSpeed;
    }

    private void Fire() {
        if (cooldownTimer <= 0) {
            GameObject obj = objectPoolCtrl.GetPooledObject();
            if(obj == null) {
                return;
            }
            obj.transform.position = firePosition.transform.position;
            obj.transform.rotation = firePosition.transform.rotation;
            obj.SetActive(true);
            //Instantiate(bullet, firePosition.transform.position, firePosition.transform.rotation);//何を、どこにに、どれくらいの回転で
            cooldownTimer = timeInterval;
        }
    }
}
