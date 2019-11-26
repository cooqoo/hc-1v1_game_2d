using UnityEngine;

public class player : MonoBehaviour
{
    //宣告變數(定義欄位 field)
    [Range(1, 100)]
    public float speed = 1.5f;
    [Range(1f, 100f)]
    public int jump = 100;
    public bool isGround;
    public string playerName = "coo";

    public AudioClip soundatk;
    public AudioClip soundjump;
    public AudioClip soundground;
    public AudioClip soundhurt;
    public AudioClip sounddie;

    public Animator ani;

    public AudioSource aud;
    

    //定義方法 method
    
    public void move()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            print("向右走");
            ani.SetBool("跑步開關", true);

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

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            print("向左走");
            ani.SetBool("跑步開關", false);
        }
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("跳躍");
            ani.SetBool("跳躍", true);
            aud.PlayOneShot(soundjump);
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
       
    }
    private void Update()
    {
        move();
        Attack();
        Jump();


        if (Input.GetKeyDown(KeyCode.Alpha1))
        Dead();






    }


}