using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatforms : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 检查碰撞的游戏对象是否是玩家（通过名称匹配）
        if (collision.gameObject.name == "Player")
        {
            // 将玩家对象设置为此平台的子对象（实现吸附效果）
            collision.gameObject.transform.SetParent(transform);
        }
    }
    // 当带有Collider2D的游戏对象离开此平台的触发器区域时调用
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 检查离开碰撞的游戏对象是否是玩家（通过名称匹配）
        if (collision.gameObject.name == "Player")
        {
            // 将玩家对象从平台的子对象中移除（解除吸附效果）
            collision.gameObject.transform.SetParent(null);
        }
    }
}
