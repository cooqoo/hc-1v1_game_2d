using UnityEngine;

public class learnif : MonoBehaviour
{
    public bool test;
    public bool weapon;
    //start 遊戲開始執行一次
    void Start()
    {
        if (true)
        {
            print("測試");
        }

        if(test)
        {
            print("布林值勾選");
        }

        else
        {
            print("布林值取消勾選");
        }
        
        if (weapon)
        {
            print("ak47");
        }
        
        else
        {
            print("小刀");
        }


    }
    //一秒執行60次
    private void Update()
    {
        //Unity API
        //輸入.取得按鍵(按鍵列舉.名稱)
        print(Input.GetKeyDown(KeyCode.Space));

        if (Input.GetKeyDown(KeyCode.D))
        {
            print("向右走");
        }


    }


    



}
