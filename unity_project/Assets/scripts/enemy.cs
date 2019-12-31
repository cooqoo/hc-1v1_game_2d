using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [Header("血量"), Range(100, 1000)]
    public float hp = 200;
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10;
    [Header("攻擊cd"), Range(0, 10)]
    public float cd = 3;
    private float timer;
    private bool startattack;


    private Animator ani;
    private Rigidbody2D rig;
    private float groundmin;
    private float groundmax;


    private void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        Attack();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "角色") startattack = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "角色") startattack = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "碰撞")
        {
            groundmin = collision.collider.bounds.min.x;
            groundmax = collision.collider.bounds.max.x;

        }
    }
    public void Damage(float damage)
    {
        hp -= damage;
        ani.SetTrigger("hurt");
        if (hp <= 0) dead();
    }
    private void dead()
    {
        ani.SetBool("ko", true);
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<CapsuleCollider2D>().enabled = false;
    }
    private void Move()
    {
        if (startattack) return;
        rig.AddForce(-transform.right * speed);
        ani.SetBool("跑步開關", true);
    }
    private void Attack()
    {
        if(startattack)
        {
            if(timer < cd)
            {
                timer += Time.deltaTime;
                ani.SetBool("跑步開關", false);
            }
            else
            {
                timer = 0;
                ani.SetTrigger("New Trigger");
            }

        }
    }

}
