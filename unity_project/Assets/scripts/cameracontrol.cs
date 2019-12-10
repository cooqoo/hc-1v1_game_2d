
using UnityEngine;

public class cameracontrol : MonoBehaviour
{
    [Header("目標物件")]
    public Transform target;
    //在transform底下(粗體字元件)
    [Header("速度"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("水平與直線範圍限制")]
    public Vector2 limitHorizontal;
    public Vector2 limitVerticle;

    private void Track()
    {
        
        Vector3 postarget = target.position; 
        //抓玩家座標
        Vector3 postcamera = new Vector3(postarget.x, postarget.y, -10);
        //給攝影機一個新的座標                玩家座標.x玩家座標.y
        //  攝影機       夾住             在這個座標裡面(x=橫向 y=高度)
        postcamera.x = Mathf.Clamp(postcamera.x,limitHorizontal.x ,limitHorizontal.y);
        postcamera.y = Mathf.Clamp(postcamera.y,limitVerticle.x, limitVerticle.y);
        //攝影機座標      指定為         算完的差值      lerp=插值 抓出中間的值讓攝影機跟         
        transform.position = Vector3.Lerp(transform.position, postcamera, speed * Time.deltaTime);

    }
    //慢更新一偵再動作通常用於攝影機(建議)
    private void LateUpdate()
    {
        Track();
    }
}
