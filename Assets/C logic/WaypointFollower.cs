using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; // 声明一个用于存储路径点的游戏对象数组
    private int currentWaypointIndex = 0; // 当前路径点的索引，初始化为0

    [SerializeField] private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //添加错误报告
        if (waypoints.Length == 0)
        {
            Debug.LogError("Waypoints array is empty!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //为了让陷阱自动循环往复移动，只移动一次就不用恢复0 了
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position,transform.position) < .1f)// 检查当前游戏对象与当前路径点之间的距离是否小于0.1（表示接近路径点）
        {
            currentWaypointIndex ++;//自增
            // 如果当前路径点索引超出了路径点数组的长度，重置为第一个路径点索引（循环移动）
            if (currentWaypointIndex >= waypoints.Length)//到达末尾
            {
                currentWaypointIndex = 0;//回到起点
            }
            
        }
        // 移动游戏对象向下一个路径点位置 speed 速度
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
