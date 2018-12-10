using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TestLock : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BookShop book = new BookShop();
        //创建两个线程同时访问Sale方法
        Thread t1 = new Thread(new ThreadStart(book.Sale));
        Thread t2 = new Thread(new ThreadStart(book.Sale));
        //启动线程
        t1.Start();
        t2.Start();
        Timer timer = new Timer((obj) =>
        {
            Debug.Log("==1111==" + book.num + " : " + obj);
        }, "obj", 1000, -1);
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

class BookShop
{
    //剩余图书数量
    public int num = 1;
    public void Sale()
    {
        lock (this)
        {
            int tmp = num;
            if (tmp > 0)//判断是否有书，如果有就可以卖
            {
                Thread.Sleep(1000);
                num -= 1;
                Debug.Log(string.Format("售出一本图书，还剩余{0}本", num));
            }
            else
            {
                Debug.Log("没有了");
            }
        }
    }
}
