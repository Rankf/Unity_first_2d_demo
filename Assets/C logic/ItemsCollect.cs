using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCollect : MonoBehaviour
{
    private int bananas = 0;
    [SerializeField] private Text bananasText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Trigger 触发器触发
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 检查碰撞的物体是否带有 "Banana" 标签
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);//毁坏碰撞体
            bananas++;
            // 更新 UI 文本显示当前的香蕉数量
            bananasText.text = "Bananas:" + bananas;
        }
    }
}
