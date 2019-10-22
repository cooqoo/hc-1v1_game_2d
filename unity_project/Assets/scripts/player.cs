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

    public AudioClip[] sounds; 
    

    //定義方法 method
    public void move()
    {
        print("移動");
    }
    private void Start()
    {
        move();
    }
    private void Update()
    {
        move();
    }
}