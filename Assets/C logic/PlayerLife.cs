using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D player; // 玩家的刚体组件，用于物理控制
    private Animator anim; // 玩家的动画组件

    // Start 方法在游戏开始前调用一次
    void Start()
    {
        player = GetComponent<Rigidbody2D>(); // 获取玩家的 Rigidbody2D 组件
        anim = GetComponent<Animator>();     // 获取玩家的 Animator 组件
    }

    // Update 方法每帧调用一次
    void Update()
    {

    }

    // 碰撞检测方法（用于处理刚体之间的碰撞）
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 检查碰撞的物体是否带有 "Trap"（陷阱）标签
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die(); // 触发死亡方法
        }
    }

    // 死亡方法
    private void Die()
    {
        player.bodyType = RigidbodyType2D.Static; // 将玩家的刚体类型设为静态（停止物理运动）
        anim.SetTrigger("death"); // 触发动画中的 "death" 触发器，播放死亡动画
    }

    // 重新加载关卡的方法
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
