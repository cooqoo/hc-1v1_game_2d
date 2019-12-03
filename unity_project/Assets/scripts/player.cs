using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
   //定義一個欄位
    [Range(1, 100)]
    public float speed = 1.5f;
    [Range(1f, 1000f)]
    public int jump = 100;
    public bool isGround;
    public string playerName = "coo";

    public AudioClip soundatk;
    public AudioClip soundjump;
    public AudioClip soundground;
    public AudioClip soundhurt;
    public AudioClip sounddie;
    public AudioClip soundcoin;
    public Text textCoin;
    private int coin;
    private Animator ani;

    private AudioSource aud;
    

    //物理作用
    private Rigidbody2D r2d;
    private Transform tra;
    


    //定義方法 method
    //print輸出一個資訊(幾分幾秒做了什麼)
    //if判斷有沒有 如果...則...


    public void move()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            print("向右走");
            ani.SetBool("跑步開關", true);
            tra.eulerAngles = new Vector3(0, 0, 0);
           
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            print("向右走");
            ani.SetBool("跑步開關", false);

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            print("向左走");
            ani.SetBool("跑步開關", true);
            tra.eulerAngles = new Vector3(0, 180, 0);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            print("向左走");
            ani.SetBool("跑步開關", false);
            

        }
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("kick"))return;
        

        float f = Input.GetAxis("Horizontal");

        r2d.AddForce(new Vector2(speed * f, 0));





    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isGround) 
        {
            isGround = false;
            print("跳躍");
            ani.SetBool("跳躍", true);
            aud.PlayOneShot(soundjump);

            r2d.AddForce(new Vector2(0, jump));
        }


        


    }
    public void Hurt()
    {
        print("受傷");
        ani.SetTrigger("hurt");
        aud.PlayOneShot(soundhurt);
    }
    public void Dead()
    {
        print("死亡");
        ani.SetBool("ko", true);
        aud.PlayOneShot(sounddie,5);
        
    }
    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            print("攻擊");
            ani.SetTrigger("New Trigger");
            aud.PlayOneShot(soundatk);
        }
    }
    
    private void Start()
    {
        ani = GetComponent<Animator>();//抓檔案
        aud = GetComponent<AudioSource>();
        r2d = GetComponent<Rigidbody2D>();
        tra = GetComponent<Transform>();


    }
    private void Update()
    {
        move();
        Attack();
        Jump();


        if (Input.GetKeyDown(KeyCode.Alpha1))
        Dead();


    }
    //collision=存放碰到東西的資訊
    private void OnCollisionEnter2D(Collision2D collision)//偵測碰撞地板
    {
        if (collision.gameObject.tag == "地板")
        {
            isGround = true;
            ani.SetBool("跳躍", false);
            aud.PlayOneShot(soundground,1f);
            //欄位本身已經定義成小數點，f代表音量
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)//針對有勾TRIGGER的
    {
        if (collision.gameObject.tag=="coin")
        {
            aud.PlayOneShot(soundcoin);
            Destroy(collision.gameObject);
            coin ++;
            textCoin.text = "金幣:" + coin;
        }
    }
    
        
    
}