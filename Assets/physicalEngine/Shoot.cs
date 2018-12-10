using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject ball;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dis1 = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,30)); //获取鼠标位置并转换成世界坐标
        Vector3 dis = dis1 - ball.transform.position;
        transform.eulerAngles = dis;
        transform.position = dis; //使物体跟随鼠标移动
        //Debug.Log( Input.mousePosition  + " : "+ dis); //输出变化的位置
                    //使用Lerp方法实现 这里的Time.deltaTime是指移动速度可以自己添加变量方便控制
        //this.transform.position = Vector3.Lerp(this.transform.position, dis, Time.deltaTime);
        ////使用MoveTowards方法实现，这个方法是匀速运动
        //this.transform.position = Vector3.MoveTowards(this.transform.position, dis, Time.deltaTime);
        ////使用SmoothDamp方式实现,给定时间可以获取到速度
        //Vector3 speed = Vector3.zero;
        //this.transform.position = Vector3.SmoothDamp(this.transform.position, dis, ref speed, 0.1f);
        ////Debug.Log(speed);
    }
}
